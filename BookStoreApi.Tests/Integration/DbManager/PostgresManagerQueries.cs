using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreApi.Tests.Integration
{
    public class PostgresManagerQueries
    {
        public const string ResetSchema = @"
                                            DROP SCHEMA IF EXISTS shop CASCADE;
                                            CREATE SCHEMA shop;";

        public const string CreateDb = @"
                                         CREATE OR REPLACE FUNCTION pg_temp.create_database
                                            (host TEXT, database TEXT, username TEXT, password TEXT)
                                         RETURNS void AS $create_database$
                                         DECLARE 
                                            _server_conn TEXT := 'host=' || host || ' user=' || username || ' password=' || password;
                                         BEGIN  
                                            CREATE EXTENSION IF NOT EXISTS dblink;
                                            PERFORM dblink_connect(_server_conn);

                                            PERFORM pg_terminate_backend(pid)
                                            FROM pg_stat_activity
                                            WHERE pid <> pg_backend_pid()
                                            AND pg_stat_activity.datname = database;
        
                                            IF EXISTS (SELECT TRUE FROM pg_database WHERE datname = database) THEN
                                                PERFORM dblink_exec('DROP DATABASE ' || database);
                                            END IF;
                
                                            PERFORM dblink_exec('CREATE DATABASE ' || database);
                                         END 
                                         $create_database$
                                         LANGUAGE plpgsql;
                                         SELECT pg_temp.create_database(@host, @database, @user, @password);";

        public const string DropDb = @"
                                        CREATE OR REPLACE FUNCTION pg_temp.drop_database
                                            (database TEXT, username TEXT, password TEXT)
                                        RETURNS void AS $drop_database$
                                        BEGIN 
                                             CREATE EXTENSION IF NOT EXISTS dblink;

                                             PERFORM pg_terminate_backend(pid)
                                             FROM pg_stat_activity
                                             WHERE pid <> pg_backend_pid()
                                             AND pg_stat_activity.datname = database;

                                             PERFORM dblink_exec('dbname=' || current_database() || 
                                             ' password=' || password || ' user=' || username, 
                                             'DROP DATABASE IF EXISTS ' || database);
            
                                         END 
                                         $drop_database$
                                         LANGUAGE plpgsql;
                                         SELECT pg_temp.drop_database(@database, @user, @password);";
    }
}
