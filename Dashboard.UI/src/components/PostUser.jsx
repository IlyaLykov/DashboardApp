import React, { useState } from "react";
import MyButton from "./UI/button/MyButton";
import MyInput from "./UI/input/MyInput";

const PostUser = ({ create }) => {
    const [user, setUser] = useState({ userId: '', dateRegistration: '', dateLastActivity: '' })

    const addNewUser = (e) => {
        e.preventDefault()
        const newUser = {
            ...user
        }
        create(newUser)
        setUser({ userId: '', dateRegistration: '', dateLastActivity: '' })
        console.log("user created")
    }

    return (
        <form>
            <table>
                <thead>
                    <tr>
                        <th>UserID</th>
                        <th>Date Registration</th>
                        <th>Date Last Activity</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>
                            <MyInput
                                value={user.id}
                                onChange={e => setUser({ ...user, userId: e.target.value })}
                                type='number'
                                placeholder='User ID'
                            />
                        </td>
                        <td>
                            <MyInput
                                value={user.dateRegistration}
                                onChange={e => setUser({ ...user, dateRegistration: e.target.value })}
                                type='date'
                            />
                        </td>
                        <td>
                            <MyInput
                                value={user.dateLastActivity}
                                onChange={e => setUser({ ...user, dateLastActivity: e.target.value })}
                                type='date'
                            />
                        </td>
                    </tr>
                </tbody>
            </table>
            <MyButton onClick={addNewUser}>Create user</MyButton>
        </form>
    )
}

export default PostUser;