import axiosConfig from '../axios.config';

const END_POINT_API = {
    NguoiDungURL : "NguoiDung"
}

export const getNguoiDungAPI = () => {
    return axiosConfig.get(`${END_POINT_API.NguoiDungURL}`);
};