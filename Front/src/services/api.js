import axios from "axios";

const api = axios.create({
    baseURL : "http://localhost:5242/",
})

export default api;