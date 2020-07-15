import { DecimalPipe } from "@angular/common";

export class Containers {
  Id: number;
  OrderId: number;
  SizeId: number;
  ContainerNumber: string;
  ChassisId: number;
  ClientId: number;
  SealNumber: string;
  Temperature: number;
  Weight: DecimalPipe;
  POPChassisFlag: boolean;
  UserId: number;
  CreateDate: Date;
  LastUpdateDate: Date;
  StatusId: number;

}
