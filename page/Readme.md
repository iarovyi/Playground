
# Steps

```javascript
mkdir docs
cd docs
npm init
npm install webpack webpack-cli webpack-dev-server --save-dev
npm install sass-loader css-loader sass --save-dev
npm install html-webpack-plugin mini-css-extract-plugin --save-dev
```

Change package.json:
```json
"scripts": {
	"start": "webpack serve",
	"build": "webpack"
},
```

```javascript
@"
const path = require('path');
const MiniCssExtractPlugin = require('mini-css-extract-plugin')
const HtmlWebpackPlugin = require('html-webpack-plugin')

module.exports = {
    entry: './src/index.js',
    output: {
        filename: 'bundle.js',
        path: path.resolve(__dirname, 'dist'),
    },
    plugins: [
        new HtmlWebpackPlugin({
            template: './src/index.html',
        }),
        new MiniCssExtractPlugin({
            filename: '[name].css',
        }),
    ],
    mode: "production",
    devtool: "source-map",
    module: {
        rules: [
            {
                test: /\.scss$/,
                use: [
                    { loader: MiniCssExtractPlugin.loader },
                    'css-loader',
                    'sass-loader'
                ],
            }
        ],
    },
};
"@ | out-file -encoding ascii ./webpack.config.js

mkdir src
@"
<html>
<head></head>
<body>
    <span>Hello, this is page!</span>
</body>
</html>
"@ | out-file -encoding ascii ./src/index.html

@"
import styles from "./styles.scss"
console.log('Hello');
"@ | out-file -encoding ascii ./src/index.js

@"
body {
    span {
        color: blue;
    }
}
"@ | out-file -encoding ascii ./src/styles.scss

@"
node_modules
"@ | out-file -encoding ascii ./.gitignore
```

# Develop

```javascript
npm run start
npm run build
```