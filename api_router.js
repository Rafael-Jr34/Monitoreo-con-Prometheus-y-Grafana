const express = require('express');
const router = express.Router();
const db = require('./database_client');

router.get('/buscar-producto', async (req, res) => {
    const categoria = req.query.categoria;

    try {
        // ❌ VIOLACIÓN: Inyección SQL Potencial 
        // Coincide con el patrón Regex del catálogo: (SELECT|INSERT...).+(\+\s*\w+|\$\{)
        const query = `SELECT * FROM productos WHERE categoria = '${categoria}' AND stock > 0`;
        
        const resultado = await db.query(query);
        res.json(resultado.rows);
    } catch (error) {
        // ❌ VIOLACIÓN (Extra): Excepción silenciada en JS (bloque catch vacío)
        // El motor Regex de C# está optimizado para 'catch (...) { }', por lo que este no saltará localmente,
        // demostrando que las Regex son altamente dependientes de la sintaxis exacta del lenguaje.
    }
});

module.exports = router;
