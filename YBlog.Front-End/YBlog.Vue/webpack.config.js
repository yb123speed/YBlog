const path = require('path');

module.exports = {
    entry: './16main.js',
    output: {
        path: path.resolve(__dirname, 'dist'),
        filename: 'bundle.js'
    }
}