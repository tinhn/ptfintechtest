import React, { useContext } from "react";
import { Link } from "react-router-dom";
import { AppContext } from "./AppContextProvider";
import { serverLink } from "../main";
import { toast } from "react-hot-toast";
import axios from "axios";

function Header() {
    const { setIsAuth, isAuth, setIsLoading, loading, userName, setUserName } =
        useContext(AppContext);

    const handleLogout = async () => {
        setIsLoading(true);
        try {
            const { data } = await axios.get(`${serverLink}/account/logout`, {

            });
            setIsAuth(false);
            toast.success(data.message);
            console.log(data);
            setIsLoading(false);
        } catch (error) {
            setIsAuth(true);
            toast.error(error.response.data.message);
            setIsLoading(false);
        }
    };

    return (
        <nav className="main-navbar">
            <div>
                <h2>Simple Task Demonstration</h2>
            </div>

            <div className="right-nav">
                <ul>
                    {" "}
                    <Link to="/">Home</Link>
                </ul>

                {isAuth ? (
                    <>
                        <button disabled={loading} onClick={handleLogout} className="btn">
                            Welcome {userName}: Logout
                        </button>
                    </>
                ) : (
                    <ul>
                        {" "}
                        <Link to="/login">Login</Link>
                    </ul>
                )}
            </div>
        </nav>
    );
}

export default Header;
