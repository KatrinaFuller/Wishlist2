import Axios from 'axios'
let baseUrl = location.host.includes('localhost') ? 'https://localhost:5001/' : '/'

let auth = Axios.create({
  baseURL: baseUrl + "account/",
  timeout: 3000,
  withCredentials: true
})

export default class AuthService {
  static async Login(creds) {
    try {
      let res = await auth.post('login', creds)
      return res.data
    } catch (e) {
      throw new Error('[login failed] :' + e.response.data)
    }
  }
  static async Register(creds) {
    try {
      let res = await auth.post('register', creds)
      return res.data
    } catch (e) {
      throw new Error('[registration failed] :' + e.response.data)
    }
  }
  static async Logout() {
    try {
      let res = await auth.delete('logout')
      return true
    } catch (e) {
      throw new Error('[logout failed] :' + e.response.data)
    }
  }
  static async Authenticate() { 
    try {
      let res = await auth.get('authenticate')
      return res.data
    } catch (e) {
      console.warn('[Authentication failed] :' + e.response.data)
    }
  }
}
