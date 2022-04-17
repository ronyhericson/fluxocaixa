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

}

const fluxoCaixaService = new FluxoCaixaService();

export default fluxoCaixaService;