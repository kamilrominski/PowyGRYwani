export function isAdmin() {
  return localStorage.getItem("isAdmin") == "true";
}

export function isUser() {
  return JSON.parse(localStorage.getItem("id")) !== null;
}

export function getId() {
  return JSON.parse(localStorage.getItem("id"));
}
