import * as React from "react";
import { ListItem, ListItemProps } from "./ListItem";
export interface ListProps { items: Array<ListItemProps> }
export class List extends React.Component<ListProps> {
    render() {
        const Items = this.props.items.map((item) => {
            return <ListItem name={item.name} rank={item.rank} points={item.points}></ListItem>
        })
        return (
            <ol>
                { Items}
            </ol>
        );
    }
}