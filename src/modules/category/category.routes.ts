import Elysia, { StatusMap, t } from "elysia";
import { ResponseError } from "../../utils/ResponseError";
import { categoryService } from "./category.service";

export const categoryRoutes = new Elysia({
  prefix: "/category",
  name: "Category",
}).error({
  ResponseError,
});

categoryRoutes.get(
  "/",
  async () => {
    const allCategories = await categoryService.getAllCategories();
    return allCategories;
  },
  {
    detail: {
      tags: ["Category"],
      description: "Get all categories",
    },
  }
);

categoryRoutes.get(
  "/:id",
  async ({ params }) => {
    const { id } = params;

    if (isNaN(Number(id))) {
      throw new ResponseError(StatusMap["Bad Request"], "Invalid id");
    }

    const category = await categoryService.getCategoryById(Number(id));

    if (category instanceof ResponseError) {
      throw category;
    }

    return category;
  },
  {
    params: t.Object({
      id: t.String(),
    }),
    detail: {
      tags: ["Category"],
      description: "Get a category by id",
    },
  }
);

categoryRoutes.post(
  "/",
  async ({ body }) => {
    const serviceReturn = await categoryService.createCategory(body);

    if (serviceReturn instanceof ResponseError) {
      throw serviceReturn;
    }

    return serviceReturn;
  },
  {
    body: t.Object({
      name: t.String(),
    }),
    detail: {
      tags: ["Category"],
      description: "Create a new category",
    },
  }
);
