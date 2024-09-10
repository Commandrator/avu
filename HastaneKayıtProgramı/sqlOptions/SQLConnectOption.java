/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package sqlOptions;

/**
 *
 * @author CASPER
 */
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;
public class SQLConnectOption {
    private static Connection connection;
    public static Connection getConnection() {
        if (connection == null) {
            String url = DBConfig.getDatabaseUrl();
            String user = DBConfig.getDatabaseUsername();
            String password = DBConfig.getDatabasePassword();
            try {
                connection = DriverManager.getConnection(url, user, password);
            } catch (SQLException e) {
                e.printStackTrace();
            }
        }
        return connection;
    }

    public static void closeConnection() {
        if (connection != null) {
            try {
                connection.close();
            } catch (SQLException e) {
                e.printStackTrace();
            }
        }
    }
}
