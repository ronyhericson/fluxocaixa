import axios from "axios";

const instance = {
    axios : {}
}
let vsBaseUrl = 'http://host.docker.internal:8001/api/v1'

instance.axios = axios.create({    
     baseURL: vsBaseUrl,
    responseType:'json',
});

axios.defaults.headers.get['Content-Type'] ='application/json;charset=utf-8';
axios.defaults.headers.get['Access-Control-Allow-Origin'] = '*';

export default instance;