using System;
using System.Collections.Generic;
using System.Text;
using Core.Libs.Integration.GoogleMap.Models.Places.Geocoding;

namespace Core.Libs.Integration.Test.Manual
{
    partial class Program
    {
        static void Main(string[] args)
        {
            // TestGoogleMap();

            TestHamilton();

            // StringTest();

            // var polylineString = "a~l~Fjk~uOwHJy@P";

            // var a = (polylineString);

            // var polyliner = new Polyliner();
            // var polyline = "}fxaAg~|lSUb@OVKJSTIFIBQHqBl@kA?A?A?gB?KEECC?A?E?mD@}@AuC?A?a@?kB?uAAoB?oBAoB?oBAoB?c@@kMCsKAcA?yC?mCAiCAwAAA?w@Cy@?}@A}BES?o@Ak@B_DLK@C@GDI?U@Y?O?G?kA?}@?s@COAQAk@Gc@Ia@IEAo@S]Oe@So@[gBcAsAu@WQYSuAw@}@e@}@g@[OuAu@cB{@{Aw@AA_@QOIcFqC]QaB{@i@Y}BgA[OaD{Ay@a@gBs@u@_@}@c@wAq@KGeCkAk@WYMs@_@uBcA_@Q[Oy@a@e@U}@c@_EsBWI{BgA{@c@}BgAiCqAw@a@qFiCoEyByCwAuCwAu@]YOWMiB}@c@S{Au@YMOIGCICOGWMWI[I]GYGSCIAWCA?UAM?KAW?G?[?C?_@BU@eBLm@FqAL{@Fm@FQ@WBI@oAJkBPg@BU@U@U@U@UASASAUCs@OUEWG]Ic@M]M_A[sAe@WIa@Oa@M]MMEQGa@Q]O]UMMSQQUEIEGEIg@}@KOOUIOe@q@S]MQg@y@QYAAKQGMEEQYCEQWWc@S_@OYKSISGUEQEWEWC]CW]iDIw@EYKm@GWIWIUIUIQMW_@o@QU[a@_@]a@_@QMQMUKWMUGe@OkA[KCqC{@o@Q{DkAEA_Cs@UIQGOEQKOGMIQMOIIGOMUSMMaBkBeAsAaAoAW[s@{@eHsIgE}EaCsCq@{@k@o@q@{@]a@iAqAIMiAoAgCwCaC}CSWe@g@m@o@SSeAkASWCAACEGqAaBu@u@wAeBEGg@o@i@m@u@y@SSGGUSSOUOMIOIUKUGUIYGYEWEYCWAa@?y@BiAHI@mBNqCRoDXO@sDXs@H_Gb@aAFsCTqCTy@HO@qBPC?aAFI@iAH]Bq@HgAHaBL}ANu@Fk@D_AH_AHM@kAJmAHu@FUDkAHaAHu@Fc@Dq@F{ALwAL_@B_AH]Dk@Da@D{AJyAPq@F[BWD{ATyAL[@_ADG@qAJW@G@s@FmALqALWBg@D[Bg@DG@qAN_@DSBy@HgBHS@c@Dc@Bc@Dc@Dc@Dc@DO@g@HI@]DE?_BL{AJ_AHyBNg@Fg@F[DI@c@Dc@Ba@DI@C?}@Fy@Do@DkAHMBc@Be@DYBo@@A?_@D]D_AHWDe@Dc@BWBmBLkBb@a@Dc@D]ByBVa@DyANi@FyALaGn@gCXiE`@q@Jw@HkCXeD^cGl@[D{@JmBPyBTgBTaAL_D^u@JWFeALkBVq@FeAN}@HmC^{BZSDgBVA@gCXOBg@FwDj@_Fv@a@FgBViDd@kANw@JI@a@Fc@FC@u@HKBa@FC?oANg@HUD[DuARa@Fc@FG@eBTaAN_@Fi@F[BUBQ?E?U?YAYAWCAASCWEUGYKa@OmAe@[Ma@OcFmBMGQGoBu@uCgAaDmA_Bo@_A_@_@OoAg@sBw@}EiBECw@]cDiA_@OeEyA_@MaA]oIsDiDuAgDqAqD}AiBoAq@m@IMU[Ug@Yq@M[KYK]I_@Ga@G_@C_@C[A_@?]@a@Ba@B]Hu@NcAL{@BODa@L}@BUHq@XoB@K\\}Bh@{DDUPgATaBR{ABQL}@BSNkABKJs@`@cDHm@BM@M@O@U?i@Aw@ASCoACk@Am@E_AAQCyACiA?IGkAA_@Ae@AKAqACe@Cg@A}@A]Cw@AUCeAEcBAKCy@EyCCg@EeBAMG}BIuCGiCEqBA_@AUGsCGiCCsAYyJGmCAYGgC?UAYEkA?GGiBA]AYGqCK}DCq@GyCKqA?GEsAAmA?II}DA]GiCAk@CoAQiCEwA?UMcFOkCCyAk@iEQk@UcACOc@uAK_@AA]_AO_@GMGSMa@Ma@AEK[M_@Ma@Ma@Oa@AEK[Ma@M_@Ma@K]ACKYI][eAsAwD_@mAEMkAkDgAcDuAgEOa@o@qBqAyDOa@aAwCi@_BISIUIWIQAAKOIKCE[[MMECIGQKSIKEECSGQEg@IqAOk@GsBWaC[eAOgAOa@E]EEAkC]c@G_@EsDe@gBUc@GGA}@MiBU}@Mk@I{@KkAOqC]a@Gi@G_AMyDg@{@KiDc@oC]UCiC]AAg@Gc@Ee@Gc@C[Ac@?]?WBa@Bc@Fu@Ha@DyANuCZ_BPe@Dk@Ho@FeBPaCVS@kCZc@Dc@FG?YDo@FWBc@Da@FM@UB{@Jm@JKBUDMBYJ]LYLUJSNOH[VMLQPQRORMPKPCBIPUb@_@r@i@dAEJQ^QZGLSb@Ub@c@|@a@p@CFS^]b@]\\QTc@^YX]T]TIFSLIDSJIDSJ]Nk@Pk@RwA^yAb@ODa@LMDi@Nk@NIBQF_@LeAZaAXa@JUHoA\\a@J?@wBj@e@NaAVs@Rm@JYFUB[BWBY@_@?[?_@A_@Ae@Ey@I{AOEAa@Ec@Gm@G_CYgDa@eCYgBSw@IKCUCUCMCQCSE[GUIWIYMSKUOOIWQCAYS}@k@uA}@}@k@[S_BgAyBuAWQ]S_DsBOKyCoBgAs@s@e@[Sm@_@i@_@]U]SsBuAuBsAy@k@oD_CSMQKSMUKUKQGUGSGMAIAMCMAQASASAwBK{DQYAc@AWCYCUCSGUGUISKQKQOOMMOMQGKGMEICMCIAACKAKAIAEES?IACAQAM?ECY?CCe@Ca@?ACe@Cc@?KCYCc@Cc@C_@?EEc@Cc@?EC_@Cc@Ce@Cc@C]AECe@Cc@C[?IEc@?MCUEc@ASAOAOA?ASAAAMAGCIAICECIAGCICECGEGEGOUSWCAQQGEQMKGGEEAKEEAKEAAQEAA[IC?a@KKCsA[iCm@aAWa@IiBc@s@Oa@ISCUCWCW?e@?c@@c@@gAFyBHq@B_@@C?WAUAYEUEKCICUKQIMICAUQY[MQGKACMWAEGOEQEMGUEKGUKc@I_@I]I_@K_@I]I_@CMEKKc@EOESKa@K_@ACEOEQKc@EQEQKa@Kc@Mc@CMGUKa@Kc@EWWcAIc@Ka@Kc@Ia@EQg@oBGYG]EYCYA[C]?[?a@?e@BoA?k@@k@@eB?SFsE@]BqDByAF_GBkADyDBeA@s@Am@Ac@E]Ga@GYIWGQEMEMGOCKCGAEGQGOEQSk@Si@Se@Oe@Qc@ISg@sAM]Qg@Yw@Qc@Qg@M_@M_@K]AGK_@Ie@Ga@Cg@Cc@AS?WA{@?gCAuDAuDAaH?_@?]@Y@Y?G?E?I@K@MF]Ly@RqAJo@NiAVgBHg@VeBFg@BYFc@z@_GFc@Hi@Fc@Fc@Fc@Hc@RwABQFc@Fc@Ho@DWFc@Hi@D[Fc@Fc@Fc@Fc@Fc@NeAFc@Hc@?CRaB@ED_@D_@@KNsAH{@?CHq@@Q@U@O?M@WA_@?QAQCOAKCIG]G_@Mc@Mg@O_@Qc@i@qAEIwDkJk@uAO_@uCeHaA_CeBoEWs@KYK]cAoDK_@g@iBK]ESEMKc@iCwJOk@a@_BEIQy@q@iDMi@]cBYoAUoAMo@Qy@c@sBg@}BYkAg@eBW_AAAa@kAMa@Ma@AGW{@Og@cAgDW{@_@gA[aAi@cB[iAaAeDMc@G[Ka@EUI[Qs@Mg@Qq@Me@Mk@Om@Ka@K_@Qs@Mi@Ia@Kc@G[E]ESAOA[?a@?K?m@@e@?W?YCiBAY@y@Bu@@k@@[@WAK?a@AUCWCUEQCOm@}CCIGc@Ic@Ic@Ga@AAGa@AAGc@Ie@Ic@AKWsAe@iCYsAMk@Mu@AKE_@AICc@AMGm@@W?K@E@K@KFm@NsBDi@Da@Da@@YBSFs@Du@B_@B[Hs@B[Be@Be@?aA?g@A]A_@Eg@AKCc@Km@COCQG[Ia@Oc@Mg@KYIYMYQ_@KUOYS]U]W_@U[qA{A{@eAi@o@_@c@]c@a@c@qCiDoA{Ae@k@U[AAS_@Sa@Ma@IUKa@GUEWSqAWcB{@eFKo@Ga@UsAMe@GYGUIWGSMe@Ws@sDaLc@wAk@oBe@yAi@aBOe@g@aBWw@KYy@kCGS]_AUg@]o@m@iAi@_A{AmCYk@S]Q[CKGOGOEKCKCIEIIc@I_@Ga@C[Ee@?Y?_@@c@@a@Bc@Fa@BKDUBMJa@Jc@Le@bB_G`@{AxAkFLe@@CBGDQHYDUDS@W@Q?KAM?OCQCSGYIWMWIOOQQQOMEE_@UUKA?WKECQGSE]Ka@K[KiDaAmA]YG[G]G[CkBQu@Ic@EYEs@Ik@Gc@I]Ia@K[K[MUKqGiD}BkAqAs@mBcAqAq@SIa@UmCwAIE_B{@cAi@a@USKaAi@MIkCuA]S]Q_@SMIOI]Q_@S]Q]S_@QGEECOIOIOGMIOI]Q_@S]QSKOKmDgBy@c@c@Us@]gAm@YQ}@g@{Ay@mAo@cCoAUQUQUWWYa@c@a@k@w@_AyD}E_CwCaBsBkByBiBcBe@c@kAaA}@u@_BsAgBsA}BuBiFmEeA}@c@_@][kB}AcBuASQ{BmBcAy@yD_DcDmCa@a@_@]eA_AWSa@]a@]qBeBGC{BoBgA}@m@i@ECm@g@IGGGcByAmB}AWSoA}@e@_@]YoC_C_@[k@g@sBgBqAgAaAy@CCAA[WKIMMOKKK[UYW[WOMAAQOOMCA[Y]YWSEE]W]Y]WKIQO]W]Y}AkAw@m@YSiA{@GEuDwCaAu@sFeE[WiCoB{@q@gDiC[UCCeDgCiAy@{AkAGEwEqD[UIGKI_HiFu@i@EEs@i@GE{FmEoAcAsL_JKGs@k@w@o@i@c@][[_@[_@CCg@m@iAwAOSGGU[}AoBQUqCkDW[sBkCo@u@eDeEcBsBKMgB{Be@k@eDeEwBmCgAqAwBmCcAoAW[W[MQuBkCiB}BaCyCs@_AyAmBmCcD{AiBg@q@k@{@_AwAeAeBiB}CsBkDeEeHKQgJ{Oe@w@ACgGiKuBkDuAaCw@uAeDuFgCiES_@oCsEoAwBwEaIiGiK_DqFU]yGgLS]CCoAsBQ[eDsFS]sDkGaAaBcAaBYi@OWa@s@i@aA]}@Q_@Qc@{@qBWk@a@gAq@cB_AyBEKKUwAiDQc@MYaB{DsAcDYs@e@gAgBoE{@sBWo@i@mAw@iBe@kAuAiDaAyBgCiGO_@{AsD_A{BoCwGWq@k@mBU{AMaAGi@e@qDE[]iC]oC_@uCKu@AMEk@Ak@@mADc@Be@l@eEn@aE@KVkBH_A@m@AaACiAEeAKyBC}@EkAEeAGwA?KCc@AUCe@E_@CSCSAIEWEUGSIUQa@KWMUoBuC{EyGkBiCEEkAcBCCWa@g@{@Wm@[s@CKMe@Qu@Kg@Ig@?AGm@Em@Ac@AG?U?CA]@_@@a@@a@BUBW^uDDc@@IN}A@EJqAT{BPuBJ}A?{@Ce@AYOgAWgAKc@Mg@g@oBU}@Oi@EOU{@Qy@M{@G}@A]?U@o@?I@YFm@Bc@NkADe@Ho@BOFc@J{@B]@CNoAHs@LwA@M?Q?S?_@Ca@CO?CAGIk@Oi@Qa@]w@W]GK]_@IKGKMQ_@e@]_@SYUYOSa@e@W[OU_BoB_@g@e@q@W[M[a@u@w@}BCGoB}FW{@EOiBqFm@oAaA_Bc@m@{ByCmAeBuAoB}@qAMSoAeB_CkD{DsFkEsGs@eAmA_Bk@y@e@u@IKMQ_AsAU[g@u@}@uACCU]_@i@CGq@_AGIq@}@qC_Ew@mAqAmBo@}@]c@U[e@q@}@cAMKa@]QKWQ]QQIm@YQGgDyA{EqB}Au@gAc@cAe@s@YWMa@Qs@[m@WYMAA_@OMIu@Yy@]KEkAi@uCoAsB{@w@]GCUKWI]M[Mc@M]KUIcFyA}Ae@aF}AoA_@s@Wg@U_@QUM[SMMMMA?SSMOKIACEEMQSWOUc@k@{AyBs@eAwDsF{A_CU[mAcBa@k@IMaAuAWa@c@k@Y[Y[]We@_@s@i@cDqB}A}@a@USKOKiDoBYO}@i@uEoCi@]QKs@_@OKy@a@_@Qw@Y}@[]Ie@Mk@MSGmBg@kAYmCu@_Cm@uD_AYImAYeGuAUEcDs@uA[cAUWGc@Ii@MWGa@Ia@Ka@Ia@Ic@Ka@Ia@IcAWa@IeAUa@Ka@Ka@Ia@KYGGCsA]c@M]KcEsAgDaAy@YwEuAa@IKAUEQCQA[CKAeHCu@Ac@Ac@?c@AoCAyFCA?c@?c@AkBAeAAoCEwBCi@?sCHmDTc@ByEVu@Bq@Bi@@aA?yEMqDG_EGc@A{@A_DG{FKoBCeAIgBKgAKc@Gg@G{BSo@Gc@EKAWCiBQgCUkAMYCw@Iu@Ii@M[ICAWIYMsAm@kD{AqAk@{@a@wCqAkDaBiAg@sAo@_Aa@_@Q_@Q]QWKGCUKcAa@}@e@[QA?QIiAc@u@[c@O_AUaCc@sBa@EA}@QmAWqDq@kASiCg@mDm@a@Ic@Ec@E]Ei@?aA?q@B}@Fc@BUB_@Da@Jo@X]N_A`@QFWFUDM@M?e@AOAMCQCYK[Ma@SWOCCWOCC[MSIYGe@Ga@AQ?]@q@Ba@B{BFaBHY@cABcABg@@c@AWESEA?]MA?o@]k@[yA}@i@[sBkAa@YgBaAsAy@a@UyA}@g@[q@_@iAq@oBmAuAw@kAs@_B_AYS[UUSi@s@S[U]wBuEQ_@O[y@}AiAsBCGQ_@cAqByAwCy@cBe@aA{@cBKUSe@GWK[GWKi@SaAWiAAEWiAUcAaAoESy@Mm@EYAEE]?AE_@?ACi@C]Ce@?QAQEgAEq@Ek@Gk@G_@K_@Oa@M]S[Yc@_@a@[WGGMKMIOMy@k@SOQUS[ACQ]AAM_@O_@KWCIO_@IUEKm@_B_@cAOa@Oa@GSEKOa@k@aBEIEMMa@IWCIK[AEAGCEAECMAAAEAMAAAKAKAIAG?EAO?EAM?K?W?I@M?M?CBQBM?C@CBMBK@KBIDKBGBG@EDKLWBET]FKLQR[@AT[BEPWNUBENYBEHSBC@GHSDMBI@K@G@CBO?E@M@E?Y?E?YAIAUAMCUAGAECUACAIIc@EWCIAIAKCMCIEYEUAMAGEQAGGc@CSCOCUCM?CE_@AGE[Ec@Gc@E_@?CAGE[Gc@AGE[EUCME[AEGc@G_@?CG]AEES?ACKACACEMEKACIQEIEKKQEIQSCCSUSUCCOOIIGIOQOOGG}@w@sAoAgAgAa@c@mA_Aq@c@e@]OIOIOIGECAECIIGEIGIICCQUAAO[AAO_@ACc@eACG{@sBCEMYCEKMk@c@w@UGAm@KYAg@C{@@{@A_@KUIk@a@IIQUi@aAq@sA]i@U[KQ}@}@A?cBcB_BgBuA{By@oBq@cBGO{@mBIQO_@U_@EIaAkA_Ac@s@a@c@Sk@Yu@[UAIA[AG@]@E?a@DA?c@BK@UBUBM@c@BE?]@U?M?c@Ac@CKAUCc@Gc@E[CEAc@Ec@Ga@Ec@Gc@Ea@GE?]Ec@Ga@EwAOy@KwFm@YEoAMiBSiBUC?m@MWGICOIQKUOa@_@MOu@}@OSSWCCOOc@_@A?[UOKe@YECe@UYKWKGCc@OSCKCUCMCOAm@ECAcAGeAKy@Io@KGAYIWK[UWSUWy@u@y@{@a@e@Wg@Se@I[G_@KeAIk@G_@Ky@Ik@?EQyAGi@CQC_@C[?GAW?K?SDu@LkA@WNoABKBWRoBPwABOL}@BGH[@EJ[\\gAj@eBBGHY\\eAh@cB@C^eANWRY`@]XQJCJEp@W@At@WJERGJIXSX]PSlAaBd@u@T]DILQT]Zg@LSp@aAh@u@b@m@DEf@e@h@a@BA\\S`@YNIt@g@zAcAn@a@`Am@\\UrBsAPKfAs@b@c@HIPSLSNWLWDOFQ?ADOBO?ABOBQBS@S?[?]AYA_@Cg@AYASA]CYCo@A_@CY?EA_@AIAY?EC]?EA_@Cc@GmAOkDCs@AMAi@?YA]@m@Dm@D_@T_CB_@HgA?IBYDe@Bc@Dg@FcA?EB_@B_@@GBeA?aA?ECQCQAKUmAYsAMaA?G?c@?kABo@@YFa@FYL]\\w@BEP]Te@PWd@{@^s@\\y@H[@EFU@M@C@W?G?MAU?ACUAKCMGUES_@sAKa@EKGUCIEWEYAICKAW?AA[?E?W@a@?O@Q?Q?]@u@Ae@Ao@?CAIAc@AKQmCG}@KgBQmCYqEK_BEs@MmBMkBEi@KaBK_BK}ACg@Cc@Em@K}ACa@Ey@Gw@IsAG]EYG[G]Me@WgAI]EQCM?ACQCQ?AAMAM?OAQ?Q@Q@O@OBQ@MBMJa@r@mCd@_BZeAH_@FWF[DUBY@[@WASA]Q_FMmDGeBAGA[GqCEiACiAIqCIsCEcCIyBAc@KsCIqCGmBCk@GeBAOAw@Ae@AKAq@?W@OBQ@MDKDOHM@CP[FKJQR]FO\\s@L[?CFQBKBIDSBQDQ@OVcC?APwAN{ADc@BOXyCBUFo@BORaBHg@F]@CJs@Fe@BQ@KBU?A@M?O?E?E?K?QASG}@AUAO?M?O@O?M@M@QHk@Dc@DYPqALcA@CFa@ZyBBU\\mCXqBD]PgA@GB[DU@S@S@U?UAQCUCKAICKGOOc@a@_ACEO_@O_@Mc@CMESKk@Ge@CWAUCO?ACOCQGUk@yA[{@Ws@GUCSA?CWAKAICYMeCOuBEy@AS]_FGcAQmCO_CCi@SuCMiBSoCGq@CS?ECMa@{Ao@cCo@{BGUW_AwAiFgAaEA?kAkEiAeEe@cB[mAa@qASk@O]_@w@_C{Eo@oA{CiGc@_AmCsFqAmCcBeDg@aA_AiBy@aBiA{Bg@eAaBaDs@}Ae@}@a@w@EEw@mAGIcAsACCW[SWk@y@U[IKc@m@U[U[U]MOIKeCeDEIW[]e@_@i@]c@MSKSAAMYMi@CIMo@CKGc@Q{@AII]ACK[c@s@GMKOIMKQe@w@Q_@IQGOEQGUC[C]IoAA]Ea@Ce@?CCa@Ci@Cg@Es@Ei@Ea@?GE_@?CGc@AMGa@Ga@E[EYGe@GWGWIUGOKQO[U_@S_@_@k@KOS[MUUm@Me@[aBUsAIc@IYCIEIEGIIAAKKMK?AKIOKA?UOa@Yg@_@MIUGWAe@Cm@E]EWEUGe@QSIQGSIOKIIMOIWOg@G]Ga@Eq@CUKUMSOOUO]Mu@Qg@QWG_@OC?KGOIQQg@s@k@m@KOIOSe@KWOSOOOM[W_@Ym@c@SM_A_@c@SGC_@Qk@]IEGGIQGMEQMa@KUQ]QWOWEMCQ?OBMBMN]NWX]LWJSFMDQBS?YEYI[Qi@Uk@k@oAWo@Ok@EYMi@GYKc@Ka@GOMYGIUWOMKMGKCEAG?O?IBWHc@@WC[Ka@Sy@Ca@GYISOUWQSKi@Q_ASk@MQEUIQI[Ss@m@][KMEMAEAQ?WFy@Dy@@c@AMGSEQQi@EY@]@e@ASCKGMGMKKIIi@[USMMMQKQQUMMYOa@Um@[OKIMCEKSIWQq@K_@IMEIIKWQSMwAq@WMMKMMIMIQIWG_@AICIGSKWKSa@o@[m@S][s@MSIKMIOIa@OUMOKIKMOIOIIW_@MMEEMGOEQAO?gAFa@BK?W?E?YCi@IWCQAW?s@Dm@Hu@Lc@FU@O?w@?o@?]?SBQDe@JcBf@SBI@a@@e@Aa@?]BC?SDSHu@^[HQBO?_@EOGKIEEAGAAAM@MBMPWPUXa@FI^e@Xg@Pk@D]Ae@?WBSDQFQHMJUHQDUD_@Be@@e@A_@AUCa@?[@SH]HSFKDMDO@KBSCWI_@Ka@EIEIOWMIUMSI_@O_@GWC_@A]@S?]@k@F_ALS@I?IASGUQk@YgAi@g@Uc@SOKIEGEIQGSGc@E_@I]K[GOKKUUAAOOSKOEUCSCW@QDSHMLKHSTKFSPMHMBQB[DiAFcAHWDQBKDKFKHKPUh@KZABQb@ELKVILEFIFMHKDMDM@a@@uABg@AM?C?QAMECAMKCCCEAEGQAS@QDMJUBGFKJSFQBK?O?WGw@C[Ee@E]?Y?Q@SDSJe@DUD[?E@]GkAEs@Ce@C_@G]I]K]EMISAEGMSW]c@i@s@_@_@OKg@U]Qa@WeAu@WOUOSIYG_@GYEOGQKQQYa@k@y@QWQSUKECSG_@GWEMAGCKIGISa@Ww@Ws@]uAOo@Ic@Ic@K[ISMMQQ_@Q[E_@?e@@Q@M@S?SCWGu@We@I_@Ig@Cc@EW?OD_@PYNUFM@YBGAm@C[IOMIKGIM][qAUoAQ}@E[@S@OBMHOPO`@Q\\I@?\\GXIf@[ZYDIHUBK?MAQCICEUWk@]e@UQMMOYg@GQSYWYe@i@WWOKOEEAMAc@?w@@[?SCOCUGWKQGMCO?O@]@WC_@Ea@Oq@Me@Gq@MSEQIGIIKIWMe@Qq@_@w@[_@e@a@AA]SMCMAMAS?W@U@U?SAUE_@Oe@]k@[]KQAKAY@g@HUBi@Ha@?A?{@KSGYK]KSIUI[KYKSGCA[OECWMQOUUSWWa@S_@OYO]IOKMEGKIe@]mAg@EAe@Uk@UYMi@Se@S_@Oe@S[M_@QA?YMECSISKYKe@SCC[KA?QKKCMGQIA?MIQQQOKOCGGGUe@S]O[OYAAO]a@w@S_@EGEIMSIQOWCGS]AEQYACOYCGKOCEU]?CQ[GKKQeBcDmAwBY_@KQSQOKUMa@OWKm@O_@Kk@OICWGSGs@Qc@Ms@Qc@M]IMCOEMEEAUIYO[QYQ_@SMKOGME_@MQEQCQAYAk@De@FeATa@Hc@Hy@Nu@LaDl@w@JQ@S@O?MASAE?o@Gm@KEAYIGAOGQGAA]Q]WQOQMgA{@s@i@[WUSaAs@AAYS[Si@YYOUKKEA?KEMC[I[G_@GA?YAi@?g@?kA?u@@M?c@?W?i@@y@?g@@uB?Q?c@?c@?[?G?c@?c@?c@?c@?E?sI@I?c@@c@?c@@G?[?uA?U?c@@{@?cD?cB?q@?_@Ac@?yACsBKoAGc@AMAoBKyAIa@C[CWA_AG}@G_@CWC[GOCYISGOGeAa@i@SeCeAaFqBmFwB}B_Ae@Sw@a@e@Sc@Uw@e@c@YOMm@e@w@q@k@g@o@o@e@a@c@c@]_@S[MQIQMUEKOc@I]G]Ag@AWCgBAsBAsA?a@?[EgAGwAOkAAIGo@MgAKw@Im@K_@So@Qg@o@eAm@o@o@i@OMsAeAkH{FWS}BaBg@i@[]{@kAYc@q@aAyBgDm@eAo@{@AGQOOOUOMIOGSEMEYI]I]ICAiCc@gB]cAUUG_@Me@Sc@YSOa@_@OWKMKQWk@U}@G[McAKgA?IC[OkBM{ACSKk@I[IUS_@GOoAcBe@q@c@k@iDwEuAgBuDaFs@_Ao@}@e@}@Yk@Uo@e@wAw@{BK]Yw@w@iCKYM_@o@aBg@aAIOcB{Cy@_Bi@_Am@aAk@eAe@cAg@}@IOg@_A_AcBg@_AKQCECIg@}@Q]{@aBCCq@mAo@mAcByCyBeEcAeBu@iB]_Ae@cBu@gCg@gBgBaG_@qAe@gBa@uBc@kCS}Ac@kCq@mEo@gEy@_FQiAS{ACMQ{@U}@AEc@_Ac@u@IKk@}@]g@MMUYU]U[U[W]U[U]U[KMKOcCqDeBmCMQwAsBU]U[GKMOIM_@i@GI]g@Sa@Mm@EUCMCY?KAg@@q@@_@?I@QF}B@SDs@DqABa@HsABsA@OJuDBk@@]?E?CJmCHsBBg@BUDQBUHQDUHQR[HIFIp@s@ZUTOj@[TM|@g@p@o@`@M`Ag@dCsAxBmAvBoAJETM\\UVOb@e@Va@zAaCj@cAn@gAHMl@eAHMt@oAn@gAX_@X_@b@[ZUZSz@g@\\S\\Sh@a@hAo@nAy@XWV[@?LW@EJWFSFSBSDY@_@C[M{@ESK_@EUGWKc@e@uBKg@s@aDGO]cB}@eDs@gDYoAKa@G]Qu@I{@Cw@@g@Da@@GLo@L[L]t@qA?AR[d@s@t@aAFKj@y@BGJQPWb@m@Z]^Wl@W`Aa@v@QlBk@r@Uz@W^MNG\\Wf@m@\\u@ZqAf@aCHc@TcAJc@TgAb@eBdAgFr@uCJq@Hm@Du@A}@AEM{BI_B]kDEk@Ec@WoCKgAGe@Iy@K}AA_APkDDu@DmABe@?OF}B@SBe@Ba@FiAB[@Y?a@AUE]a@eEUwBWmBMk@M_@i@_AIS[g@_AaBi@y@c@_AWo@g@wA]iAe@}AUoAAGKs@G}@OmAS}@S[CEc@m@eBwBkB{BW_@Ma@EOEQI[AGKk@AIKs@Ig@G]Mm@CSEc@QeAKgACi@?i@Lm@Ne@Xe@^g@ZWr@_@h@W\\OHCfAg@b@Uh@YXUVWPYHOLWJm@RgA^mCh@sDdAmIDYFoCPaJFgCLiFB}@?C?uBCm@AQKs@ESIa@ACSo@i@y@cAaBU_@[c@k@}@]y@Q}@EWE_@IaAIo@ASUyBG{@SkCEk@IaAEYGc@Ga@CMUo@_@_AGMa@w@OYe@cAGMCKMi@GUCMMgAGc@Ga@Ic@Ga@Gc@Ic@Ga@?AEc@CY?I?a@?ABe@?EB]?EFe@TmADUJw@Dk@@q@KmAIsA?OCaA@}A?[?u@CcAKgAa@qAmAyByA_CiBiDs@mAw@qAKUMUeAaBg@o@k@k@_BoAmAw@iEoCMI]S]S_@S]Sk@]kBoA[QWQ]UiAs@kAw@]Um@g@g@g@e@s@Yk@SiAUkBQcB?GI{AKoAO{@W{@Yy@AA}@aBwBuDwByDs@oAeAkBqA_CaDsFgAiBQ]aByCm@kAQg@Mi@UuAGYc@oDk@cGI{@k@oFGg@a@aEGeAA}@Bk@Nk@Ro@@Gf@kAbBkDpB{DTa@bAoB`BcDN]NUN]Vk@J[Ts@HYFWFc@P}ABa@F_@@Of@gFVqCNmAx@yIN{A`@aEDm@Be@@YAQAWAYE_@EUCSIWQs@EUaAsD{AkFa@{AIa@COAKEW?EEYCWCa@Ai@@_@@S@e@Fg@BWPqAn@yBt@yAt@}ANU~AwC~BkEFMb@{@JQV_@NST[JMJMPULQVYp@u@hBuB~GyHtBcCX_@NQHO^o@LWJYJc@FUF]DYx@eILsATwB@GJeAH_ADaA@QDgAHuCReJJkAFg@Lo@x@sCf@yARi@Pi@d@yAFSL[b@yA`@qA@Ed@}ADSDQDQBOBM?EBS?K?MAYA_@CKCQEWIi@Kg@EWESE_@Cc@A[?M?U?GAo@@Q@c@@iAHwBBu@BsA@}@Cs@Iw@[_ACIc@_AGKISc@_ACGIYM_@Ee@Gc@CWEo@Eu@YsGGuAE_AMqCC]?EIgAEe@?AKeA?GGYCMCK]aAc@o@g@e@KIeAs@c@U}@c@]QkCqAeB}@uDoBa@Q{@]cB]{AOwBAeDEwCA[?c@@[@G?c@Fa@DK@y@Na@HE?SDaCb@gBZy@Ho@@A?c@@S?qAC{ACy@G_@CC?a@ESAOCg@I[KOGe@Sk@a@a@_@W[[o@Ka@K[AEMa@m@{Bc@eBg@sBk@}Ba@uAYw@_@s@o@_AKOiAkAsAyAuAwAQUq@u@CCYi@Ua@I_@Ga@@wAFeBV_G?A@a@HoBHuBLaC@ILy@Ps@`@}@l@iAf@w@\\e@DIZm@Vq@Je@Ha@?CAi@I_ASeAYw@IMc@w@eAaBW]W[U[IKoAuAo@{@i@y@EGS_@]y@IUw@gCaAgDg@}A]y@KMU[?Ae@i@qC_CaAcAg@m@MUS]U]S]CCOYQ_@Q]CEMYQ_@Sc@iByEQi@Oa@Ma@[cAM_@Uq@[uAK[Ka@Ma@I[AEMa@IWEIU]S]MUEGU[OWCGO_@EMESCSAO?e@Ac@A]?E?e@?c@?WAMAc@?YCIGc@?EAIQo@g@gAAAOa@O_@O[ACm@cAa@m@CCW[W[AAWWYYg@e@oBuBKMc@g@WYW[YYW]aDaEaAgA{@q@_Ao@sJ}EiB_AeCoAWM}CaBc@[YS]WYWYWs@w@c@c@YYYWKIKKa@]YUIGQOIGYScAw@o@e@w@i@SOIEWSCA]YWSWWCAOQQWO[g@}@[o@KWi@kAi@aBi@}AW}@s@iCKu@Gi@?a@?a@BY@S@ED[@AF[BELa@Na@@ANa@N[?AP]FILQ@APUBCNMHKJIVOVO^OTIHChCs@`Be@`@KBAVKXMTMPKNMJI@CLQDGBGHSDUBQ?E@[@_@A]C_@E]Ia@Ka@K_@MYO_@e@qAUo@O_@Ma@_@aAISUm@]aAOa@Sm@mAcDUq@Uo@M_@K]I_@Ig@Gi@Ge@Cc@Ai@?_A@a@Bm@@a@D]B[DSF[Ha@Jc@DOHSLYFQNWFIHKFIHKNMl@a@jAi@rCgAf@S^OfAe@~Am@z@Y^MnA]nAUpAU`@I`@KJCTGLEn@]h@g@`@e@rAgCt@}Ap@uA\\o@fAyBp@wATo@BIJ[@AH_@Hc@@??eA?Q@e@]gGGcBQwEAe@IuBE_@Gu@QmAEIMa@K]e@kAa@u@e@_Ay@}Ae@}@kA{BS_@}BkEmAiCc@cAU}@{AgHGWm@uCo@aD_@kBQaAw@}Dg@mCi@uC}AyHEY}@uEKu@E[MiAGaAAKGsBEkBMcFA[OmEQeFOoFQgFC_@C}AKuECw@E{@Cg@KwA]{DSyBM{AKiBA_@?g@B]?OBSHq@PgAViARo@\\_A@Cr@wALWR_@P]HQZk@Vi@f@eARg@HYBM@G?CBUBUB[@S?Y?_@EwCCaDAYCcEC]E]CSE[ACCUK]K[IUKWWc@S[S]m@cA[e@y@sAiAgBo@cAUa@CECG_BoBYYYWSMKGu@Yu@WkBg@kAYc@KgBe@yA_@A?y@SsA]sAYe@ImCk@mAUCAa@Kq@Qc@MgAQc@KqBc@]Gi@KwHcBm@MaASaB]sBc@cASUEMCs@O{@Oc@GWCsBO}@IQAOAcAGo@CE?sAGG?W?k@D{ALkBJqAFq@@SAK?YAm@Ee@EUIA?m@Mi@OMEIC]Qc@OOKOMMMOOc@a@a@a@_AgA_@a@[[a@c@yA}AQQIIw@u@KMKQw@cAc@y@MYKYWo@ACYmACMWkAa@iBESw@eDc@mBOq@w@mDWiAYiAk@oBa@mACEWq@q@qBiA_Dc@mAe@mAYy@q@mBYw@Wo@a@y@Ye@k@u@_AkAoCcDe@i@KMeAqAeBsBgAsA{AiBg@w@GMa@cAEIeAgDMa@IU[aAcAaD]gAwCcJa@qAY{@i@kBo@eB_@{@]i@_@g@OQSQWUe@[oBqAe@Y}@k@gDiBaAm@u@i@[Uq@e@YSUOMMQOOQMMMQQUKOGKYq@m@cBCK[oAa@_B[qAU{@eAqDSeAAUASA[@_@@MBSBOFSFOHS\\{@jAiCTg@HUlEsJzCeHnBkEfAcC^gA\\iALu@Ho@JaA@K`@eGVqDDi@Dc@b@sFDu@DgAAc@Ci@Ko@WeAk@kBs@yBWy@Y_AUi@i@eAYg@a@c@MOKKKIMIeAq@o@YYMe@S_Aa@]O_Aa@yNkG_IiD}GwCu@[qBaACA}@a@eB_AUMgCuA{BoAy@c@_Ag@gCwAq@_@iCwAECgAm@q@_@mAo@k@[}@g@yAw@wAw@kAo@o@a@g@e@a@c@Y]e@w@[q@[}@[{@gAgDi@aBKWu@aCqCoIGOyAoEa@iAYy@?AM_@Mi@SaAMeAMqAGiAIy@OwBImAGu@Bu@JaAR{@Zu@Vk@Xc@n@u@V[l@s@~EyGzD}Eb@o@j@}@Zi@Ti@Po@Nm@DYFe@FgC@{BByB@qB?Q@c@?iAH}DByD@eAB_AFkFBkFD_GBwD?c@@q@?qB?aCD}ABkC?SJcPBuC@cAJeHHyJBmA@mCCg@ASEg@Ii@Mi@UaAMm@Mi@YcAKa@g@gBg@kBkAmEi@kBg@kBy@iDCIu@oCi@iB[mA[gAS}@Kk@CWCSAM?M?WAa@BqAPaEDkADsAB_ABs@Bc@@OBs@?CBe@?ADeAPoBBWDWFo@RkB@IFgA@S@U?S?UCUCUEUI[Qa@oBaEo@sA[{@K[I]CSASAQDW@QBQDUHULUJSNUPOPSPOXO`@UTIRKNKLMNM^c@p@u@`@i@PWPYLULUJULUHS@CHSHUFSDSBMBMDKFUFMDE@AJMFEFEFCJARCTAnFEb@?b@?@AZCXELEPERINKXSTSp@k@n@m@VYXYxBuBnBoBnBaBlAeA@A^]RSTSPOb@[d@Y`@WdAm@ZS`@UHEPOZ[DEV[HILOV[@ATYV[^e@f@o@r@{@PUJOHQL[JYJ[DQFUJi@Li@Pw@VeAJa@Ji@VeAJa@VeAJa@Lk@ZwAF_@@YD_@@S?[CaCAu@AkACiCEuEAu@AsAA[C[Kw@AEKc@AAI_@Ka@IUo@{B_@qAOi@GWMm@EUCQCQAM?WA}AAa@Ag@C]AUEYES{@oDMc@WcAKa@e@eB}@kDi@oBSu@]qA_@aBMg@EMGSISIWKSKQYa@U]y@cAa@e@o@u@W[IKmAaBc@q@Ug@IUK]ESCMEUCWAK?GA[Cc@ImBAY@o@?G?Q@OB]@I?CDQBKDQFM?AJWBIJ]@CDKNs@Hi@HeA?AB]?EJkCJiBDwABo@Da@BQ@CHY@GFU@ABIDKBGFK?AJO@AJQPS`AcAhAoAx@q@b@_@^e@X[VWVWPULQDIFMDMFSFUBSD_@@m@By@@uC?A?kB@c@?U?o@CqAA[ACAQCQAEEYEUGUa@qAc@}@_@s@Q]Sa@e@_Au@sAkA}BWg@Ua@wDuHy@cBOWcAsBs@sAm@wAc@oAa@uAq@cCo@wBSu@Ma@Ma@CKi@oBGOESCK]kAOi@GUI[EQCOACAMCQ?CCYAWC[?_@AYAk@?[@a@@u@@a@@OJyBF_BD}A@[?G@e@Bg@DgB?A@c@Bc@@e@?W@K?K?U?C?OAWAUCSCUGYGWGWIWCIEKIQMWMUSYSYSYY[WYYY_@]y@}@o@q@y@}@a@k@MUU_@Yi@Qa@KWIYAAK_@EOEQKa@?AKa@Mk@Qw@Mg@ESCMI]AEaAuEGUGa@Ke@_AmEUmA[qAEUg@oBw@yBi@mAM]oAqCMU[u@s@sAe@gAM]Wo@Mc@IUESCMCGCQCIEYEa@CYC[AOAS?c@@_@@_@@YB]Fy@Do@Fw@Di@HiAHiA\\yFDi@DeAFu@LkAJs@Lc@BMHSDKVm@HSDKJSVe@`@u@h@}@R]f@}@R]LSd@}@R_@d@{@p@kAh@cATq@P}@Hw@BW^mEZsDj@}FB]@[B_@@OBk@@m@?E?_@?ECc@Cc@C_@?COwACU?GI}@AIUoBOqAc@wDQ_BCUOmA[eDIu@MqAOwACUAYE[E]?CI_@G]Ic@G]]}AEK[kAMc@_@mASo@m@oBACI]g@kB[uAG]Gc@q@{DU_BQeAE]Ks@M}@EWAKIc@?A]{B[_CWcBMaA?CE]AEQqAIe@CSIu@Iy@K_ACMCOCKi@{BOc@Wc@]g@Y]e@]WWMMi@g@e@c@GGg@g@e@a@MKMKm@k@eA_Ae@c@YUYScA}@]Yo@[q@]}@_@_Bq@kBo@aA_@QGSIaC{@{G}BGCsFmBaC{@uAg@OEs@W{E_BuAe@WI]M]MmBq@w@_@[Y[]QWQYCEi@eAo@wAO[OYQ_@QWOYQWSUQUOKCCYOUKIEKESGGA_@KYGSCQCgAAkAHiANG@G@yAV_@Fq@Lo@PsBh@yBl@c@NaA\\gDfAcBh@gD`AiC~@o@P_IfC}A^oARw@HI@K?K@O?KAMA}@BA?OCOCUG[KwDsA_@MsDsAME_A]yBw@e@O_@OOGaBk@q@Wa@O]Oo@SsAg@_@OKEu@W{@]cBk@_@Me@Qq@UgDmA_@OeHiCaA_@_@O_@Ou@YiCkBaDmCm@g@{@s@qBcBmI_HoC_CuBgBo@k@]]g@g@m@w@iA_BuAuBgAcBe@s@uAsBWg@a@i@o@_A_AyAe@u@KQGGe@m@u@y@a@_@_@[UOYS{DkCqBwAg@W}AcAaAw@kAcA[[c@c@sAiAoAmAa@]g@a@q@g@YY_A_A_DiCwDeDwAmA_@_@a@k@KOOSIQKSMYK[M[G[UgASuAUkBEa@M{@Iy@Gg@w@mG}@mHk@mDc@yDIo@Ky@GWKg@_@_A_@u@Ua@m@_AGIq@y@Y_@e@_@k@e@IGGECCQKWOYOSKUK[KYKWIQCg@Mm@MwB_@qFaAuGiAc@GgCc@oCg@k@KgAQs@OiEu@_B[yCk@cF{@qEw@gB[cDi@sEw@CAaB[u@U_Ae@}@e@oCeBEC_VoOqD}BmBmAeFaDw@i@YSOKMKIIMMKOMQMUQ_@q@oB_BgGeBqGKc@_A{DIUYu@k@mAc@k@c@g@SSaCqB}@q@aFaEkBuAgG_FcAy@cBwAqFkESOqBaBqHcG_CkByAmAUSGEgBwAcAu@YY[UcBuAoAeAuBcBuBeBw@i@kAeAwAkAQKgB{AMKUQWOcAi@y@a@WKo@WyA_@]E]Ee@Ge@G]Cc@C[?}@EeDIyAEy@C}@C[AqCKMCKAqE[]CyAMgAIcAImD]sBMyCU{CW}AKiAOmAIg@Ee@IQCYISGQGUMUKSMYSo@k@[Y}@w@k@g@eBeB{@}@[]c@q@iBkFaAsC{@iCOc@Su@k@yA]{@Ye@]g@m@s@WSo@m@]WCC]SIQMIOIoD}Aq@[a@Q_@Sg@[w@o@u@m@";

            // var result = polyliner.Decode(polyline);
        }

        static void StringTest()
        {
            var str1 = "Thành phố Bảo Lộc";
            var str2 = "tp. Bảo Lộc";

            var a = 0;

            if (string.Compare(str1, str2, true) == 0)
                a = 1;
        }

        static IEnumerable<Location> Decode(string polylineString)
        {
            if (string.IsNullOrEmpty(polylineString))
                throw new ArgumentNullException(nameof(polylineString));

            var polylineChars = polylineString.ToCharArray();
            var index = 0;

            var currentLat = 0;
            var currentLng = 0;

            while (index < polylineChars.Length)
            {
                // Next lat
                var sum = 0;
                var shifter = 0;
                int nextFiveBits;
                do
                {
                    nextFiveBits = polylineChars[index++] - 63;
                    sum |= (nextFiveBits & 31) << shifter;
                    shifter += 5;
                } while (nextFiveBits >= 32 && index < polylineChars.Length);

                if (index >= polylineChars.Length)
                    break;

                currentLat += (sum & 1) == 1 ? ~(sum >> 1) : (sum >> 1);

                // Next lng
                sum = 0;
                shifter = 0;
                do
                {
                    nextFiveBits = polylineChars[index++] - 63;
                    sum |= (nextFiveBits & 31) << shifter;
                    shifter += 5;
                } while (nextFiveBits >= 32 && index < polylineChars.Length);

                if (index >= polylineChars.Length && nextFiveBits >= 32)
                    break;

                currentLng += (sum & 1) == 1 ? ~(sum >> 1) : (sum >> 1);

                yield return new Location
                {
                    lat = Convert.ToDouble(currentLat) / 1E5,
                    lng = Convert.ToDouble(currentLng) / 1E5
                };
            }
        }

        static string Encode(IEnumerable<Location> locations)
        {
            var str = new StringBuilder();

            var encodeDiff = (Action<int>)(diff =>
            {
                var shifted = diff << 1;
                if (diff < 0)
                    shifted = ~shifted;

                var rem = shifted;

                while (rem >= 0x20)
                {
                    str.Append((char)((0x20 | (rem & 0x1f)) + 63));

                    rem >>= 5;
                }

                str.Append((char)(rem + 63));
            });

            var lastLat = 0;
            var lastLng = 0;

            foreach (var point in locations)
            {
                var lat = (int)Math.Round(point.lat.Value * 1E5);
                var lng = (int)Math.Round(point.lng.Value * 1E5);

                encodeDiff(lat - lastLat);
                encodeDiff(lng - lastLng);

                lastLat = lat;
                lastLng = lng;
            }

            return str.ToString();
        }
    }
}