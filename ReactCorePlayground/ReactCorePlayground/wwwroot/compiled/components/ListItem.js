"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.ListItem = void 0;
const React = require("react");
class ListItem extends React.Component {
    render() {
        return React.createElement("li", null,
            this.props.name,
            ": ",
            this.props.points,
            " points");
    }
}
exports.ListItem = ListItem;
//# sourceMappingURL=ListItem.js.map