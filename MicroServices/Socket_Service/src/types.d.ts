// src/types.d.ts
import "fastify";

declare module "fastify" {
  interface FastifyReply {
    startTime: number;
  }
}