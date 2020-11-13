import http from "./httpService";
import { apiUrl } from "../config.json";

const apiEndpoint = apiUrl + "/branches";

function branchUrl(id) {
  return `${apiEndpoint}/${id}`;
}

export function getBranches() {
  return http.get(apiEndpoint, {
    params: {
      userId: "x"
    }
  });
}

export function getBranch(branchId) {
  return http.get(branchUrl(branchId));
}

export function saveBranch(branch) {
  branch.userId = "x";

  if (branch.id) {
    const body = { ...branch };
    delete body.id;
    return http.put(branchUrl(branch.id), body);
  }

  return http.post(apiEndpoint, branch);
}

export function deleteBranch(branchId) {
  return http.delete(branchUrl(branchId));
}
