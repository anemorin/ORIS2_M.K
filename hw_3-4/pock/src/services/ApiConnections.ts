import axios from "axios";

export const ApiConnection = axios.create({
    baseURL: 'http://localhost:5022/api/',
    headers: {
    //   'Access-Control-Allow-Origin': '*',
    },
    maxContentLength: 512 * 1024 * 1024,
  });