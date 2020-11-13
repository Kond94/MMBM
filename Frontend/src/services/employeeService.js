import http from "./httpService";
import { apiUrl } from "../config.json";

const apiEndpoint = apiUrl + "/employees";

function employeeUrl(id) {
  return `${apiEndpoint}/${id}`;
}

export function getEmployees() {
  return http.get(apiEndpoint, {
    params: {
      userId: "x"
    }
  });
}

export function getEmployee(employeeId) {
  return http.get(employeeUrl(employeeId));
}

export function saveEmployee(employee) {
  employee.userId = "x";

  if (employee.id) {
    const body = { ...employee };
    delete body.id;
    return http.put(employeeUrl(employee.id), body);
  }

  return http.post(apiEndpoint, employee);
}

export function deleteEmployee(employeeId) {
  return http.delete(employeeUrl(employeeId));
}
