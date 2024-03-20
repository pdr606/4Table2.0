import { StatusMap } from "elysia";

export class ResponseError extends Error {
  status: valueof<StatusMap>;
  message: string;

  constructor(status: valueof<StatusMap>, message: string) {
    super(message);
    this.status = status;
    this.message = message;
  }
}
