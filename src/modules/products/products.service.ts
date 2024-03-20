import { StatusMap } from "elysia";
import { db } from "../../database";
import { ResponseError } from "../../utils/ResponseError";
import { CreateProductDTO } from "./dtos/create-product.dto";

export const productsService = {
  async getAllProducts() {
    return await db.selectFrom("products").selectAll().execute();
  },

  async getProductByCategory(categoryId: number) {
    return await db
      .selectFrom("products")
      .selectAll()
      .where("category_id", "=", categoryId)
      .execute();
  },

  async getProductById(id: number) {
    const productData = await db
      .selectFrom("products")
      .selectAll()
      .where("id", "=", id)
      .executeTakeFirst();

    if (!productData) {
      return new ResponseError(StatusMap["Not Found"], "Product not found");
    }

    return productData;
  },

  async createProduct(data: CreateProductDTO) {
    const result = await db
      .insertInto("products")
      .values(data)
      .returningAll()
      .executeTakeFirst();

    if (!result) {
      return new ResponseError(
        StatusMap["Internal Server Error"],
        "Error creating product"
      );
    }

    return result;
  },
};
