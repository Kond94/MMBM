import http from "./httpService";
import { apiUrl } from "../config.json";

const apiEndpoint = apiUrl + "/shops";

function shopUrl(id) {
  return `${apiEndpoint}/${id}`;
}

export function getShops() {
  return http.get(apiEndpoint, {
    params: {
      userId: "x"
    }
  });
}

export function getShop(shopId) {
  return http.get(shopUrl(shopId));
}

export function saveShop(shop) {
  shop.userId = "x";

  if (shop.id) {
    const body = { ...shop };
    delete body.id;
    return http.put(shopUrl(shop.id), body);
  }

  return http.post(apiEndpoint, shop);
}

export function deleteShop(shopId) {
  return http.delete(shopUrl(shopId));
}
