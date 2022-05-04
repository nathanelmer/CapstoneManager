import React from "react";
import { Switch, Route, Redirect } from "react-router-dom";
import Login from "./Login";
import Register from "./Register";
import ClassList from "./ClassList";
import { StudentList } from "./StudentList";
import { StudentDetails } from "./StudentDetails";
import { StudentEdit } from "./StudentEdit";

export default function ApplicationViews({ isLoggedIn }) {
    return (
        <main>
            <Switch>
                <Route path="/" exact>
                    {isLoggedIn ? <ClassList /> : <Redirect to="/login" />}
                </Route>
                <Route path="/login">
                    <Login />
                </Route>
                <Route exact path="/class/:id(\d+)">
                    <StudentList />
                </Route>
                <Route exact path="/class/student/details/:id(\d+)">
                    <StudentDetails />
                </Route>
                <Route exact path="/class/student/edit/:id(\d+)">
                    <StudentEdit />
                </Route>
                <Route path="/register">
                    <Register />
                </Route>
            </Switch>
        </main>
    );
};