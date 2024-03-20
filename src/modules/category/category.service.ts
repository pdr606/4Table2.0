import { StatusMap } from "elysia";
import { db } from "../../database";
import { ResponseError } from "../../utils/ResponseError";
import { CreateCategoryDTO } from "./dtos/create-category.dto";

export const categoryService = {
  async getAllCategories() {
    return await db.selectFrom("product_categories").selectAll().execute();
  },

  async getCategoryById(id: number) {
    const categoryData = await db
      .selectFrom("product_categories")
      .selectAll()
      .where("id", "=", id)
      .executeTakeFirst();

    if (!categoryData) {
      return new ResponseError(StatusMap["Not Found"], "Category not found");
    }

    return categoryData;
  },

  async createCategory(data: CreateCategoryDTO) {
    const result = await db
      .insertInto("product_categories")
      .values(data)
      .returningAll()
      .executeTakeFirst();

    if (!result) {
      return new ResponseError(
        StatusMap["Internal Server Error"],
        "Error creating category"
      );
    }

    return result;
  },
};
