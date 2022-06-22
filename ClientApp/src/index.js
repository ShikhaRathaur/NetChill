
import React from 'react';
import ReactDOM from 'react-dom';
import {   BrowserRouter as Router,
} from 'react-router-dom';
import App from './App';
import registerServiceWorker from './registerServiceWorker';

import 'bootstrap/dist/css/bootstrap.min.css';

import 'bootstrap/dist/js/bootstrap.bundle.min.js';

const baseUrl = document.getElementsByTagName('base')[0].getAttribute('href');
const rootElement = document.getElementById('root');



ReactDOM.render(
  <Router basename={baseUrl}><App /></Router>,
   rootElement);
   
registerServiceWorker();

