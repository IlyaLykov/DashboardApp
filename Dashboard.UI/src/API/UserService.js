import axios from "axios";

export default class UserService {

    static async getHistogramData() {
        try {
            const response = await axios.get('https://localhost:44360/api/users');
            return response.data;
        } catch (e) {
            console.log(e);
        }
    }

    static async getRollingRetention() {
        try {
            const response = await axios.get('https://localhost:44360/api/users/rolling_retention');
            return response.data;
        } catch (e) {
            console.log(e);
        }
    }

    static async postUser(user) {
        await axios.post('https://localhost:44360/api/users', user);
    }

    static async postUsers(users) {
        users.forEach(user => {
            this.postUser(user);    
        });
    }
}