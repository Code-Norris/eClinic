import React, { Component } from "react";
import { makeStyles } from '@material-ui/core/styles';
import Card from '@material-ui/core/Card';
import CardActions from '@material-ui/core/CardActions';
import CardContent from '@material-ui/core/CardContent';
import Button from '@material-ui/core/Button';
import Typography from '@material-ui/core/Typography';
import AuthService from '../services/AuthService';

export default class SignIn extends Component {
    constructor(props) {
        super(props)
        this.authsvc = new AuthService();
    }

    render() {
        return (
            <div className="signin">
                <Card className="signinCard" variant="outlined" >
                    <CardContent style={{ display:'flex', justifyContent:'center' }}>
                        <Typography color="textSecondary" gutterBottom>
                            Welcome to eClinic
                        </Typography>
                        
                    </CardContent>
                    <CardActions style={{ display:'flex', justifyContent:'center' }}>
                        <Button variant="contained" color="primary" onClick={this.login}>
                            Azure AD Login
                        </Button>
                    </CardActions>
                </Card>
            </div>
        );
    }

    login = () => {
        console.log('button clicked')
        this.authsvc.oidcSignin();
    }
}