"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.List = void 0;
const React = require("react");
const ListItem_1 = require("./ListItem");
class List extends React.Component {
    render() {
        const Items = this.props.items.map((item) => {
            return React.createElement(ListItem_1.ListItem, { name: item.name, rank: item.rank, points: item.points });
        });
        return (React.createElement("ol", null, Items));
    }
}
exports.List = List;
//# sourceMappingURL=List.js.map