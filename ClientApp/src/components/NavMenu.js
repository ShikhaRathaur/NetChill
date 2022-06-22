import React from 'react'
import { Link } from 'react-router-dom';
import '../static/style.css';

export default function NavMenu() {
    return (
        <nav className="navbar navbar-expand-lg navbar-dark" id="navigation"> 
            <div className="container-fluid">
                
                <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                    <span className="navbar-toggler-icon"></span>
                </button>
                <div className="collapse navbar-collapse" id="navbarSupportedContent">
                    <ul className="navbar-nav mr-auto">
                        <li className="nav-item">
                            <Link className="nav-link active" aria-current="page" to="/Home/Ui"><b>Home</b></Link>
                        </li>
                        <li className="nav-item">
                            <Link className="nav-link active" to="/Home/Ui/featured"><b>Featured</b></Link>
                        </li>
                       
                        <li className="nav-item">
                            <Link className="nav-link active" to="/Home/Ui/newrelease"><b>New Releases</b></Link>
                        </li>
                        <li className="nav-item">
                            <Link className="nav-link active" to="/Home/Ui/upcoming"><b>Upcoming</b></Link>
                        </li>
                        <li className="nav-item">
                            <Link className="nav-link active" to="/Home/Ui/mylist"><b>My List</b></Link>
                        </li>
                       
                    </ul>

                    <ul className="navbar-nav ml-auto">
                       
                            <a className="nav-link active" aria-current="page" href="/Logout"><b>Logout</b></a>
                       
                    </ul>


                </div>
            </div>
        </nav>
    )
}
