export interface Product {
  id: string;
  code: string;
  name: string;
  description: string;
  price: number;
}

export interface CreateProductRequest {
  code: string;
  name: string;
  description?: string;
  price: number;
}

export interface UpdateProductRequest extends CreateProductRequest {
  id: string;
}

