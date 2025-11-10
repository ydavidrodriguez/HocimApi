import { FastifyReply, FastifyRequest } from "fastify";
import { RoundRepository } from "../Repository/round.repository";

export default class RoundCtrl {
  constructor(private readonly roundRepository: RoundRepository) {}

  public goToNextRound = async (
    request: FastifyRequest,
    reply: FastifyReply
  ) => {
    const body = request.body;
    const response = await this.roundRepository.goToNextRound(body);
    reply.status(response.status).send({
      status: response.status,
      msg: response.msg,
      data: response.data,
    });
  };

  public getRoundActive = async (
    request: FastifyRequest,
    reply: FastifyReply
  ) => {
    const body = request.body as any;
    const response = await this.roundRepository.getRoundActive(body.auctionId);
    reply.status(response.status).send({
      status: response.status,
      msg: response.msg,
      data: response.data,
    });
  };

  public getRoundActiveByUser = async (
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
    const response = await this.roundRepository.getRoundActiveByUser(
      body.auctionId,
      body.userId
    );
    reply.status(response.status).send({
      status: response.status,
      msg: response.msg,
      data: response.data,
    });
  };

  public getLatestRound = async (
    request: FastifyRequest,
    reply: FastifyReply
  ) => {
    const body = request.body as any;
    const response = await this.roundRepository.getLatestRound(body.auctionId);
    reply.status(response.status).send({
      status: response.status,
      msg: response.msg,
      data: response.data,
    });
  };

  public validateSaveResponseRound = async(
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
    if(!body.idSubasta){
      return reply.status(400).send({
        status: 400,
        msg: "No se encontro el id de subasta",
        data: {},
      });
    }

    const response = await this.roundRepository.validateSaveResponseRound(body.idSubasta,
      body.items.length
    );
    reply.status(response.status).send({
      status: response.status,
      msg: response.msg,
      data: response.data,
    });
  };

  public saveResponseRound = async (
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
    const response = await this.roundRepository.saveResponseRound(body);
    reply.status(response.status).send({
      status: response.status,
      msg: response.msg,
      data: response.data,
    });
  };

  public getResumeRoundByUser = async (
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
    const response = await this.roundRepository.getResumeRoundByUser(body);
    reply.status(response.status).send({
      status: response.status,
      msg: response.msg,
      data: response.data,
    });
  };

  public getResponseItemProviderJaponesa = async (
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
    const response = await this.roundRepository.getResponseItemProviderJaponesa(body);
    reply.status(response.status).send({
      status: response.status,
      msg: response.msg,
      data: response.data,
    });
  };
}
