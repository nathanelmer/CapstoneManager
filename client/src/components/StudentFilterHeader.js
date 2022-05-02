import React from "react";
import { Navbar, NavItem, NavLink } from "reactstrap";

export const StudentFilterNav = () => {

    return (
        <div>
            <Navbar color="light" dark expand="md">
                <NavItem>
                    <NavLink to="/">Not Completed</NavLink>
                </NavItem>
                <NavItem>
                    <NavLink to="/">Needs Review</NavLink>
                </NavItem>
                <NavItem>
                    <NavLink to="/">Reached MVP</NavLink>
                </NavItem>
            </Navbar>
        </div>
    )
}