import React, { Component } from "react";
import { makeStyles } from '@material-ui/core/styles';
import Card from '@material-ui/core/Card';
import CardActions from '@material-ui/core/CardActions';
import CardContent from '@material-ui/core/CardContent';
import Button from '@material-ui/core/Button';
import Typography from '@material-ui/core/Typography';
import AuthService from '../services/AuthService';

export default class SignIn extends Component {
    constructor() {
        this.authsvc = new AuthService();
    }

    render() {
        return (
            <Card className="signin" variant="outlined">
                <CardContent>
                    <Typography color="textSecondary" gutterBottom>
                        Welcome to eClinic
                    </Typography>
                    
                </CardContent>
                <CardActions>
                    <Button variant="contained" color="primary" onClick={this.login}>
                        Azure AD Login
                    </Button>
                </CardActions>
            </Card>
        );
    }

    login() {
        this.authsvc.signIn();
    }
}