import Elysia, { StatusMap, t } from "elysia";
import { productsService } from "./products.service";
import { ResponseError } from "../../utils/ResponseError";

export const productRoutes = new Elysia({
  name: "Products",
  prefix: "/products",
}).error({
  ResponseError,
});

productRoutes.get(
  "/",
  async ({ query }) => {
    const { category_id } = query;
    if (category_id) {
      if (isNaN(Number(category_id))) {
        return new ResponseError(
          StatusMap["Bad Request"],
          "Invalid category_id"
        );
      }

      const products = await productsService.getProductByCategory(
        Number(category_id)
      );

      return products;
    }

    const allProducts = await productsService.getAllProducts();
    return allProducts;
  },
  {
    detail: {
      tags: ["Products"],
      description: "Get all products",
    },
    query: t.Object({
      category_id: t.Optional(t.String()),
    }),
  }
);

productRoutes.get(
  "/:id",
  async ({ params }) => {
    const { id } = params;

    if (isNaN(Number(id))) {
      return new ResponseError(StatusMap["Bad Request"], "Invalid id");
    }

    const product = await productsService.getProductById(Number(id));

    if (product instanceof ResponseError) {
      throw product;
    }

    return product;
  },
  {
    params: t.Object({
      id: t.String(),
    }),
    detail: {
      tags: ["Products"],
      description: "Get a product by id",
    },
  }
);

productRoutes.post(
  "/",
  async ({ body }) => {
    const serviceReturn = await productsService.createProduct(body);

    if (serviceReturn instanceof ResponseError) {
      throw serviceReturn;
    }

    return serviceReturn;
  },
  {
    body: t.Object({
      name: t.String(),
      price: t.Number(),
      ingredients: t.Array(t.String()),
      category_id: t.Number(),
    }),
    detail: {
      tags: ["Products"],
      description: "Create a new product",
    },
  }
);
