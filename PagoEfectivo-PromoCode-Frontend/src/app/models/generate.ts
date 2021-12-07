export interface GenerateRequest {
    fullname: string;
    email: string;
}

export interface GenerateResponse {
    code: string;
    message: string;
}