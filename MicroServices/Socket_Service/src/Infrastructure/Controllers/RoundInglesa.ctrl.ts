import { FastifyReply, FastifyRequest } from "fastify";;
import { RoundInglesaRepository } from "../Repository/roundinglesa.repository";
export default class roundInglesactrl {
    constructor(private readonly roundInglesaRepository: RoundInglesaRepository) {}

    public IncreaseTimeRoundInglesa = async (
        request: FastifyRequest,
        reply: FastifyReply
      ) => {
        const body = request.body;
        const response = await this.roundInglesaRepository.TimeRound(body);
        reply.status(response.statusCode).send({
          status: response.statusCode,
          msg: response.message,
          data: response.data,
        });
      }

      public CreateOfferRequestInglesa = async (
        request: FastifyRequest,
        reply: FastifyReply
      ) => {
        const body = request.body;
        const response = await this.roundInglesaRepository.CreateOffer(body);
        reply.status(response.statusCode).send({
          status: response.statusCode,
          msg: response.message,
          data: response.data,
        });
      }

      public SuspendAuctionInglesa = async (
        request: FastifyRequest,
        reply: FastifyReply
      ) => {
        const body = request.body;
        const response = await this.roundInglesaRepository.SuspendAuctionInglesa(body);
        reply.status(response.statusCode).send({
          status: response.statusCode,
          msg: response.message,
          data: response.data,
        });
      }

      public ResumeAuctionInglesa = async (
        request: FastifyRequest,
        reply: FastifyReply
      ) => {
        const body = request.body;
        const response = await this.roundInglesaRepository.ActivateAuctionInglesa(body);
        reply.status(response.statusCode).send({
          status: response.statusCode,
          msg: response.message,
          data: response.data,
        });
      }

      public EndAuction = async (
        request: FastifyRequest,
        reply: FastifyReply
      ) => {
        const body = request.body;
        const response = await this.roundInglesaRepository.EndAuction(body);
        reply.status(response.statusCode).send({
          status: response.statusCode,
          msg: response.message,
          data: response.data,
        });
      }

      

    }
