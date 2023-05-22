import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Cv } from './components/Cv';

export default class App extends Component {
    render() {
        return (
            <Layout>
                <Route exact path='/' component={Cv} />
            </Layout>
        );
    }
}
