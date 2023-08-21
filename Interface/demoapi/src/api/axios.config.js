import axios from "axios";

const instance = axios.create({
    baseURL : import.meta.env.VITE_BASE_URL_API,
    timeout : 300000
});

instance.interceptors.response.use(
    (response) => {
        return response.data;
    },
    (error) => {
        console.log(error);
    }
)

export default instance;