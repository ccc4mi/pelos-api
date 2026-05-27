// config.js - Archivo de configuración global del Frontend
const CONFIG = {
    // Usa dinámicamente la URL actual del navegador en lugar de hardcodear localhost
    API_BASE_URL: window.location.origin,
    
    // Rutas de los endpoints de la API
    get PRODUCTOS_ENDPOINT() {
        return `${this.API_BASE_URL}/api/Productos`;
    }
};


window.APP_CONFIG = CONFIG;