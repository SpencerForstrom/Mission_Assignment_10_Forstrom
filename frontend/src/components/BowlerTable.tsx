import React, { useEffect, useState } from "react";

type Bowler = {
  bowlerID: number;
  bowlerFirstName: string;
  bowlerMiddleInit?: string;
  bowlerLastName: string;
  bowlerAddress: string;
  bowlerCity: string;
  bowlerState: string;
  bowlerZip: string;
  bowlerPhoneNumber: string;
  team: {
    teamName: string;
  };
};

const BowlerTable = () => {
  const [bowlers, setBowlers] = useState<Bowler[]>([]);

  useEffect(() => {
    fetch("https://localhost:5001/api/Bowlers")
      .then((res) => res.json())
      .then((data) => setBowlers(data))
      .catch((err) => console.error("Error fetching bowlers:", err));
  }, []);

  return (
    <div>
      <h2>Marlins & Sharks Bowlers</h2>
      <table>
        <thead>
          <tr>
            <th>Name</th>
            <th>Team</th>
            <th>Address</th>
            <th>City, State, Zip</th>
            <th>Phone</th>
          </tr>
        </thead>
        <tbody>
          {bowlers.map((b) => (
            <tr key={b.bowlerID}>
              <td>
                {b.bowlerFirstName}{" "}
                {b.bowlerMiddleInit ? b.bowlerMiddleInit + " " : ""}
                {b.bowlerLastName}
              </td>
              <td>{b.team.teamName}</td>
              <td>{b.bowlerAddress}</td>
              <td>
                {b.bowlerCity}, {b.bowlerState} {b.bowlerZip}
              </td>
              <td>{b.bowlerPhoneNumber}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default BowlerTable;
