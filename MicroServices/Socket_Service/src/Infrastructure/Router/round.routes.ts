import RoundCtrl from "../Controllers/round.ctrl";
import RoundHolandesaCtrl from "../Controllers/roundholandesa.ctrl";
import RoundInglesaCtrl from "../Controllers/RoundInglesa.ctrl"
import container from "../container";
const roundCtrl: RoundCtrl = container.get("ctrl.round");
const roundHolandesaCtrl: RoundHolandesaCtrl = container.get("ctrl.roundholandesa");
const roundInglesaCtrl: RoundInglesaCtrl = container.get("ctrl.roundinglesa");

const userRoutes = [
  {
    versionApi: "v1",
    method: "POST",
    url: "/go-to-next-round",
    handler: roundCtrl.goToNextRound,
    schema: {},
  },
  {
    versionApi: "v1",
    method: "POST",
    url: "/get-round-active",
    handler: roundCtrl.getRoundActive,
    schema: {},
  },
  {
    versionApi: "v1",
    method: "POST",
    url: "/get-latest-round",
    handler: roundCtrl.getLatestRound,
    schema: {},
  },
  {
    versionApi: "v1",
    method: "POST",
    url: "/get-round-active-by-user",
    handler: roundCtrl.getRoundActiveByUser,
    schema: {},
  },
  {
    versionApi: "v1",
    method: "POST",
    url: "/save-response-round",
    handler: roundCtrl.saveResponseRound,
    schema: {},
  },
  {
    versionApi: "v1",
    method: "POST",
    url: "/validate-response-round",
    handler: roundCtrl.validateSaveResponseRound,
    schema: {},
  },
  {
    versionApi: "v1",
    method: "POST",
    url: "/get-resume-round-by-user",
    handler: roundCtrl.getResumeRoundByUser,
    schema: {},
  },

  {
    versionApi: "v1",
    method: "POST",
    url: "/save-response-round-holandesa",
    handler: roundHolandesaCtrl.saveRoundHolandesa,
    schema: {},
  },
  {
    versionApi: "v1",
    method: "POST",
    url: "/get-round-active-by-user-holandesa",
    handler: roundHolandesaCtrl.getRoundActiveHolandesa,
    schema: {},
  },
  {
    versionApi: "v1",
    method: "POST",
    url: "/save-response-item-round-holandesa",
    handler: roundHolandesaCtrl.saveResponseRoundHolandesa,
    schema: {},
  },
  {
    versionApi: "v1",
    method: "POST",
    url: "/get-response-item-by-user-holandesa",
    handler: roundHolandesaCtrl.getResponseItemByUserHolandesa,
    schema: {},
  },
  {
    versionApi: "v1",
    method: "POST",
    url: "/get-response-item-provider-holandesa",
    handler: roundHolandesaCtrl.getResponseItemProviderHolandesa,
    schema: {},
  },
  {
    versionApi: "v1",
    method: "POST",
    url: "/get-response-Latest-RoundHolandesa",
    handler: roundHolandesaCtrl.getLatestRoundHolandesa,
    schema: {},
  },
  {
    versionApi: "v1",
    method: "POST",
    url: "/get-response-ItemProviderJaponesa",
    handler: roundCtrl.getResponseItemProviderJaponesa,
    schema: {},
  },
  {
    versionApi: "v1",
    method: "POST",
    url: "/Post-create-ItemProviderJaponesa",
    handler: roundHolandesaCtrl.saveResponseOtorgarJaponesa,
    schema: {},
  },
  {
    versionApi: "v1",
    method: "PUT",
    url: "/Put-create-TimeRoundInglesa",
    handler: roundInglesaCtrl.IncreaseTimeRoundInglesa,
    schema: {},
  },
  {
    versionApi: "v1",
    method: "POST",
    url: "/Post-create-OfferRequestInglesa",
    handler: roundInglesaCtrl.CreateOfferRequestInglesa,
    schema: {},
  },
  {
    versionApi: "v1",
    method: "POST",
    url: "/Post-create-SuspendRequestInglesa",
    handler: roundInglesaCtrl.SuspendAuctionInglesa,
    schema: {},
  },
  {
    versionApi: "v1",
    method: "POST",
    url: "/Post-create-ActivateAuctionRequestInglesa",
    handler: roundInglesaCtrl.ResumeAuctionInglesa,
    schema: {},
  },
  {
    versionApi: "v1",
    method: "POST",
    url: "/Post-create-EndAuction",
    handler: roundInglesaCtrl.EndAuction,
    schema: {},
  },

];

export default userRoutes;
