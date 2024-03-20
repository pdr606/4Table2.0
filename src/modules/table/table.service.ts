import { StatusMap } from "elysia";
import { db } from "../../database";
import { ResponseError } from "../../utils/ResponseError";
import { CreateTableDTO } from "./dtos/create-table.dto";

export const tableService = {
  async getAllTables() {
    return await db.selectFrom("tables").selectAll().execute();
  },

  async getTableById(id: number) {
    const table = await db
      .selectFrom("tables")
      .where("id", "=", id)
      .selectAll()
      .executeTakeFirst();

    if (!table) {
      return new ResponseError(StatusMap["Not Found"], "Table not found");
    }

    return table;
  },

  async createTable(data: CreateTableDTO) {
    return await db.insertInto("tables").values(data).returningAll().execute();
  },
};
