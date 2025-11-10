import { FastifyReply, FastifyRequest } from "fastify";;
import { RoundholandesaRepository } from "../Repository/roundholandesa.repository";
export default class roundholandesactrl {
    constructor(private readonly roundholandesaRepository: RoundholandesaRepository) {}

    public saveRoundHolandesa = async (
        request: FastifyRequest,
        reply: FastifyReply
      ) => {
        const body = request.body;
        const response = await this.roundholandesaRepository.saveRoundHolandesa(body);
        reply.status(response.status).send({
          status: response.status,
          msg: response.msg,
          data: response.data,
        });
      }

      public getRoundActiveHolandesa = async (
        request: FastifyRequest,
        reply: FastifyReply
      ) => {
        const body = request.body as any;
        if (!body.auctionId) {
          return reply.status(400).send({
            status: 400,
            msg: "El id de la subasta es requerido",
            data: {},
          });
        }
      
        const response = await this.roundholandesaRepository.getRoundActiveHolandesa(
          body.auctionId,
          body.userId
        );
        reply.status(response.status).send({
          status: response.status,
          msg: response.msg,
          data: response.data,
        });
      };

      public saveResponseRoundHolandesa = async (
        request: FastifyRequest,
        reply: FastifyReply
      ) => {
        const body = request.body as any;
        if (body.items.length === 0) {
          return reply.status(400).send({
            status: 400,
            msg: "No se encontraron items",
            data: {},
          });
        }
        if (!body.items) {
          return reply.status(400).send({
            status: 400,
            msg: "No se encontraron items",
            data: {},
          });
        }
        const response = await this.roundholandesaRepository.saveResponseRoundHolandesa(body);
        reply.status(response.status).send({
          status: response.status,
          msg: response.msg,
          data: response.data,
        });
      };

      public getResponseItemByUserHolandesa = async (
        request: FastifyRequest,
        reply: FastifyReply
      ) => {
        const body = request.body as any;
        if (!body.auctionId) {
          return reply.status(400).send({
            status: 400,
            msg: "El id de la subasta es requerido",
            data: {},
          });
        }
        if (!body.userId) {
          return reply.status(400).send({
            status: 400,
            msg: "El id del usuario es requerido",
            data: {},
          });
        }
        const response = await this.roundholandesaRepository.getResponseItemByUserHolandesa(
          body
        );
        reply.status(response.status).send({
          status: response.status,
          msg: response.msg,
          data: response.data,
        });
      };

      public getResponseItemProviderHolandesa = async (
        request: FastifyRequest,
        reply: FastifyReply
      ) => {
        const body = request.body as any;
        if (!body.auctionId) {
          return reply.status(400).send({
            status: 400,
            msg: "El id de la subasta es requerido",
            data: {},
          });
        }
        const response = await this.roundholandesaRepository.getResponseItemProviderHolandesa(
          body
        );
        reply.status(response.status).send({
          status: response.status,
          msg: response.msg,
          data: response.data,
        });
      };

      public getLatestRoundHolandesa = async (
        request: FastifyRequest,
        reply: FastifyReply
      ) => {
        const body = request.body as any;
        if (!body.auctionId) {
          return reply.status(400).send({
            status: 400,
            msg: "El id de la subasta es requerido",
            data: {},
          });
        }
        const response = await this.roundholandesaRepository.getLatestRoundHolandesa(
          body
        );
        reply.status(response.status).send({
          status: response.status,
          msg: response.msg,
          data: response.data,
        });
      };

      public saveResponseOtorgarJaponesa = async (
        request: FastifyRequest,
        reply: FastifyReply
      ) => {
        const body = request.body as any;
        if (!body.IdItem) {
          return reply.status(400).send({
            status: 400,
            msg: "El id del item es requerido",
            data: {},
          });
        }
        if (!body.IdRonda) {
          return reply.status(400).send({
            status: 400,
            msg: "El id de la ronda es requerido",
            data: {},
          });
        }
        if (!body.IdUsuario) {
          return reply.status(400).send({
            status: 400,
            msg: "El id del usuario es requerido",
            data: {},
          });
        }

        const response = await this.roundholandesaRepository.saveResponseOtorgarJaponesa(
          body
        );
        reply.status(response.status).send({
          status: response.status,
          msg: response.msg,
          data: response.data,
        });
      };

}