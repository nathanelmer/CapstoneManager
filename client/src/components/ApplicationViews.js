import React from "react";
import { Switch, Route, Redirect } from "react-router-dom";
import Login from "./Login";
import Register from "./Register";
import ClassList from "./ClassList";
import { StudentList } from "./StudentList";
import { StudentDetails } from "./StudentDetails";
import { StudentEdit } from "./StudentEdit";
import { StudentForm } from "./StudentForm";
import { StudentDelete } from "./StudentDelete";
import { ClassForm } from "./ClassForm";
import { ClassDelete } from "./ClassDelete";

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
                <Route exact path="/class/add">
                    <ClassForm />
                </Route>
                <Route exact path="/class/delete/:id(\d+)">
                    <ClassDelete />
                </Route>
                <Route exact path="/class/student/details/:id(\d+)">
                    <StudentDetails />
                </Route>
                <Route exact path="/class/student/edit/:id(\d+)">
                    <StudentEdit />
                </Route>
                <Route exact path="/class/student/add/:id(\d+)">
                    <StudentForm />
                </Route>
                <Route exact path="/class/student/delete/:id(\d+)">
                    <StudentDelete />
                </Route>
                <Route path="/register">
                    <Register />
                </Route>
            </Switch>
        </main>
    );
};