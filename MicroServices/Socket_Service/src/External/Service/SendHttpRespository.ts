const axios = require('axios');

/**
 * Método global para realizar solicitudes HTTP.
 * @param {string} method - Método HTTP (GET, POST, PUT, DELETE, etc.).
 * @param {string} url - URL del servicio al que se va a hacer la solicitud.
 * @param {object} [data=null] - Datos para enviar en el cuerpo de la solicitud (usado en POST, PUT, etc.).
 * @param {object} [headers={}] - Encabezados personalizados para la solicitud.
 * @returns {Promise} - Promesa que resuelve con la respuesta del servidor.
 */
export async function makeRequest(method: string, url: string, data:object|null= null, headers = {}) {
    try {
        const config = {
            method: method, // Método HTTP
            url: url,       // URL del servicio
            headers: headers, // Encabezados personalizados
            data: data      // Datos para enviar en el cuerpo
        };

        const response = await axios(config);
        return response.data; // Devuelve solo los datos de la respuesta
    } catch (error: any) {
        console.error(`Error en la solicitud ${method} a ${url}:`, error.message);
        throw error; // Relanza el error para manejarlo externamente
    }
}