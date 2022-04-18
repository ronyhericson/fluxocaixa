import axiosService from '../Utils/axios';


class FluxoCaixaService {

    getMovimentos = () => {
        return new Promise((resolve, reject) => {
            axiosService.axios.get('/FluxoCaixa')
                .then((response) => {
                    if (response.data) {
                        resolve(response.data);
                    } else {
                        reject(response.error);
                    }
                })
                .catch((error) => {
                    reject(error)
                });
        });
    }

    createMovimento = (movimento) => {
        return new Promise((resolve, reject) => {
            axiosService.axios.post('/FluxoCaixa', movimento)
                .then((response) => {
                    if (response.data) {
                        resolve(response.data);
                    } else {
                        reject(response.error);
                    }
                })
                .catch((error) => {
                    reject(error)
                });
        });
    }

    removeMovimento = (id) => {
        return new Promise((resolve, reject) => {
            axiosService.axios.delete('/FluxoCaixa/' + id)
                .then((response) => {
                    if (response.data) {
                        resolve(response.data);
                    } else {
                        reject(response.error);
                    }
                })
                .catch((error) => {
                    reject(error)
                });
        });
    }

}

const fluxoCaixaService = new FluxoCaixaService();

export default fluxoCaixaService;