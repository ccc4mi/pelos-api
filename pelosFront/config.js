// config.js - Archivo de configuración global del Frontend
const CONFIG = {
    // se cambia la url al pasar a produccion
    API_BASE_URL: 'http://127.0.0.1:5209',
    
    // Rutas de los endpoints de la API
    get PRODUCTOS_ENDPOINT() {
        return `${this.API_BASE_URL}/api/Productos`;
    }
};


window.APP_CONFIG = CONFIG;