import * as React from "react";
export interface ListItemProps { name: string, rank: number, points: number }
export class ListItem extends React.Component<ListItemProps>{
    render() {
        return <li>{this.props.name}: {this.props.points} points</li>
    }
}