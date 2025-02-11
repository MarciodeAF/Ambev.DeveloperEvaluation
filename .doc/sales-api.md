[Back to README](../README.md)

### Sales
 - Below all requested endpoints (Create / Update / CancelSale / CancelSaleProduct)

### Evidence
- /.doc/Evidence Sales

#### POST /sales/CreateSale
- Description: Add a new sale


- Request Body:
  ```json
      {
      "numberSale": 0,
      "customer": "string",
      "agency": "string",
      "products": [
        {      
          "name": "string",
          "description": "string",
          "unitPrice": 0,
          "amount": 0,     
        }
      ]
    }
  ```
- Response: 
  ```json
      {
      "success": true,
      "message": "string",
      "errors": [
        {
          "error": "string",
          "detail": "string"
        }
      ],
      "data": {
        "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        "numberSale": 0,
        "createdSale": "2025-02-11T16:48:44.899Z",
        "customer": "string",
        "totalValue": 0,
        "agency": "string",
        "updatedAt": "2025-02-11T16:48:44.899Z",
        "products": [
          {
            "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
            "name": "string",
            "description": "string",
            "unitPrice": 0,
            "discount": 0,
            "saleId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
            "status": 0,
            "amount": 0,
            "totalValue": 0
          }
        ],
        "status": 0
      }
    }
  ```


  #### PUT /sales/UpdateSale
- Description: Update a specific sale
- Path Parameters:
  - `id`: Sale ID
- Request Body:
  ```json
      {
      "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
      "numberSale": 0,
      "customer": "string",
      "agency": "string",
      "products": [
        {
          "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
          "name": "string",
          "description": "string",
          "unitPrice": 0,
          "discount": 0,
          "saleId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
          "status": 0,
          "amount": 0
        }
      ],
      "status": 0
    }
  ```
- Response: 
  ```json
      {
      "success": true,
      "message": "string",
      "errors": [
        {
          "error": "string",
          "detail": "string"
        }
      ],
      "data": {
        "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        "numberSale": 0,
        "createdSale": "2025-02-11T16:51:48.757Z",
        "customer": "string",
        "totalValue": 0,
        "agency": "string",
        "updatedAt": "2025-02-11T16:51:48.757Z",
        "products": [
          {
            "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
            "name": "string",
            "description": "string",
            "unitPrice": 0,
            "discount": 0,
            "saleId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
            "status": 0,
            "amount": 0,
            "totalValue": 0
          }
        ],
        "status": 0
      }
    }
  ```


#### PUT /sales/CanceledSale
- Description: Canceled a specific sale by ID
- Path Parameters:
  - `id`: Sale ID
  
- public enum SaleStatus
{
    Unknown = 0,
    Active,
    Canceled
}

- Request Body: 
  ```json
      {
      "id": "81d37bcd-b1d8-49b6-a3b0-17386791ae0a",
      "status": 2
    }
  ```
- Response: 
  ```json
      {
      "success": true,
      "message": "string",
      "errors": [
        {
          "error": "string",
          "detail": "string"
        }
      ],
      "data": {
        "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        "numberSale": 0,
        "createdSale": "2025-02-11T16:57:04.982Z",
        "customer": "string",
        "totalValue": 0,
        "agency": "string",
        "updatedAt": "2025-02-11T16:57:04.982Z",
        "products": [
          {
            "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
            "name": "string",
            "description": "string",
            "unitPrice": 0,
            "discount": 0,
            "saleId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
            "status": 0,
            "amount": 0,
            "totalValue": 0
          }
        ],
        "status": 0
      }
    }
  ```


#### PUT /sales/CanceledSaleProduct
- Description: Canceled a specific product at the sale by ID
- Path Parameters:
  - `id`: Sale ID  
- public enum ProductStatus
{
    Unknown = 0,
    Active,
    Canceled
}
- Request Body: 
  ```json      
    {
      "id": "d16c7ea8-cbe4-4f8f-9cfd-4e238cace8ee",
      "status": 2,
      "saleId": "81d37bcd-b1d8-49b6-a3b0-17386791ae0a"
    }
  ```
- Response: 
  ```json
          {
      "success": true,
      "message": "string",
      "errors": [
        {
          "error": "string",
          "detail": "string"
        }
      ],
      "data": {
        "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        "numberSale": 0,
        "createdSale": "2025-02-11T16:58:48.189Z",
        "customer": "string",
        "totalValue": 0,
        "agency": "string",
        "updatedAt": "2025-02-11T16:58:48.189Z",
        "products": [
          {
            "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
            "name": "string",
            "description": "string",
            "unitPrice": 0,
            "discount": 0,
            "saleId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
            "status": 0,
            "amount": 0,
            "totalValue": 0
          }
        ],
        "status": 0
      }
    }
  ```
 


