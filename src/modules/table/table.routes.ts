import Elysia, { StatusMap, t } from "elysia";
import { ResponseError } from "../../utils/ResponseError";
import { tableService } from "./table.service";

export const tableRoutes = new Elysia({
  prefix: "/tables",
  name: "Table",
}).error({
  ResponseError,
});

tableRoutes.get(
  "/",
  ({}) => {
    return tableService.getAllTables();
  },
  {
    detail: {
      tags: ["Table"],
    },
  }
);

tableRoutes.get(
  "/:id",
  async ({ params }) => {
    const { id } = params;

    if (isNaN(Number(id))) {
      throw new ResponseError(StatusMap["Bad Request"], "Invalid id");
    }

    const table = await tableService.getTableById(Number(id));

    if (table instanceof ResponseError) {
      throw table;
    }

    return table;
  },
  {
    params: t.Object({
      id: t.String(),
    }),
    detail: {
      tags: ["Table"],
    },
  }
);

tableRoutes.post(
  "/",
  ({ body }) => {
    const { number } = body;

    if (isNaN(Number(number))) {
      throw new ResponseError(StatusMap["Bad Request"], "Invalid number");
    }

    return tableService.createTable({ number: Number(number) });
  },
  {
    body: t.Object({
      number: t.String({ minLength: 1 }),
    }),
    detail: {
      tags: ["Table"],
    },
  }
);
