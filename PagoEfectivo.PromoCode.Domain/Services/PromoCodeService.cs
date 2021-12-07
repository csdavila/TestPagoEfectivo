using AutoMapper;
using Microsoft.Extensions.Logging;
using PagoEfectivo.PromoCode.CrossCuting.Enums;
using PagoEfectivo.PromoCode.Domain.Interfaces;
using PagoEfectivo.PromoCode.Infrastructure.UnitOfWork;
using PagoEfectivo.PromoCode.Model.Dtos;
using PagoEfectivo.PromoCode.Model.Models;
using PagoEfectivo.PromoCode.Model.Requests;
using PagoEfectivo.PromoCode.Model.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PagoEfectivo.PromoCode.Domain.Services
{
    public class PromoCodeService : IPromoCodeService
    {
        private readonly ILogger<PromoCodeService> _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public PromoCodeService(
            ILogger<PromoCodeService> logger,
            IMapper mapper,
            IUnitOfWork unitOfWork
            )
        {
            _logger = logger;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<PromoCodeDto>> All()
        {
            var result = await _unitOfWork.PromoCodes.All();
            return _mapper.Map<IEnumerable<PromoCodeDto>>(result.ToList().OrderByDescending(x => x.Id));
        }

        public async Task<GenerateResponse> Generate(GenerateRequest request)
        {
            //Verify
            var exist = await FindByEmail(request.email);
            if(exist != null)
            {
                if (exist.Status == (int)Status.Redeemed)
                {
                    return new GenerateResponse
                    {
                        code = string.Empty,
                        message = "El correo ingresado ya ha canjeado un código anteriormente."
                    };
                }
                else
                {
                    return new GenerateResponse
                    {
                        code = exist.Code,
                        message = "Se generó el código promocional correctamente."
                    };
                }
            }

            //Register
            PromoCodeEntity entity = new PromoCodeEntity();
            entity.Name = request.fullName;
            entity.Email = request.email;
            entity.Code = Guid.NewGuid().ToString().ToUpperInvariant();
            entity.Status = (int)Status.Generated;
            await _unitOfWork.PromoCodes.Add(entity);
            await _unitOfWork.CompleteAsync();

            //Return
            return new GenerateResponse
            {
                code = entity.Code,
                message = "Se generó el código promocional correctamente."
            };
        }

        public async Task<RedeemResponse> Redeem(RedeemRequest request)
        {
            bool result = false;
            string message;

            //Verify
            var entity = await FindByCode(request.code);
            if (entity == null)
            {
                message = "El código ingresado no existe.";
            }
            else
            {
                entity.Status = (int)Status.Redeemed;
                await _unitOfWork.PromoCodes.Update(entity);
                await _unitOfWork.CompleteAsync();
                result = true;
                message = "El código ingresado ha sido canjeado correctamente.";
            }

            //Return
            return new RedeemResponse
            {
                success = result,
                message = message
            };
        }

        private async Task<PromoCodeEntity> FindByEmail(string email)
        {
            var exists = await _unitOfWork.PromoCodes.Find(x => x.Email == email);
            if (exists.Any())
            {
                return exists.FirstOrDefault();
            }
            else
            {
                return await Task.FromResult<PromoCodeEntity>(null);
            }
        }
        private async Task<PromoCodeEntity> FindByCode(string code)
        {
            var exists = await _unitOfWork.PromoCodes.Find(x => x.Code == code);
            if (exists.Any())
            {
                return exists.FirstOrDefault();
            }
            else
            {
                return await Task.FromResult<PromoCodeEntity>(null);
            }
        }
    }
}
