const path = require("path");

module.exports = {
    entry: "./ClientApp/index.tsx",
    mode: "production",
    watch:true,
    devtool: "source-map",

    resolve: {
        extensions: [".ts", ".tsx"]
    },
    output: {
        path: path.resolve(__dirname, "wwwroot/dist"),
        filename: "[name].js"
    },
    module: {
        rules: [
            {
                test: /\.ts(x?)$/,
                exclude: /node_modules/,
                use: [
                    {
                        loader: "ts-loader"
                    }
                ]
            },
            {
                enforce: "pre",
                test: /\.js$/,
                loader: "source-map-loader"
            }
        ]
    },

    externals: {
        "react": "React",
        "react-dom": "ReactDOM",
        "react-router-dom": "ReactRouterDOM"
    }
};