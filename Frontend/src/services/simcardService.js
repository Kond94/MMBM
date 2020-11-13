import http from "./httpService";
import { apiUrl } from "../config.json";

const apiEndpoint = apiUrl + "/simcards";

function simcardUrl(id) {
  return `${apiEndpoint}/${id}`;
}

export function getSimcards() {
  return http.get(apiEndpoint, {
    params: {
      userId: "x"
    }
  });
}

export function getSimcard(simcardId) {
  return http.get(simcardUrl(simcardId));
}

export function saveSimcard(simcard) {
  simcard.userId = "x";

  if (simcard.id) {
    const body = { ...simcard };
    delete body.id;
    return http.put(simcardUrl(simcard.id), body);
  }

  return http.post(apiEndpoint, simcard);
}

export function deleteSimcard(simcardId) {
  return http.delete(simcardUrl(simcardId));
}
