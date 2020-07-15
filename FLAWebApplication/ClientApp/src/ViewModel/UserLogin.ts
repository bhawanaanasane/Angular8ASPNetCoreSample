
import { Role } from "./Role";

export class UserLogin {
  id: number;
  clientId: number;
  firstName: string;
  lastName: string;
  userName: string;
  password: string;
  contactNo: string;
  parentId: number;
  active: boolean;
  loggedIn: boolean;
  roleId: number;
  token?: string;
  role: Role[];
}
